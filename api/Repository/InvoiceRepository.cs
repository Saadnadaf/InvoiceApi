using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using api.Helpers;  
using api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _context;
        public InvoiceRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<InvoiceMaster> AddInvoiceAsync(InvoiceMaster invoice)
        {
            _context.InvoiceMasters.Add(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }

        public async Task<List<InvoiceMaster>> GetAllInvoiceAsync(QueryObject query)
        {
            var invoice = _context.InvoiceMasters.Include(i => i.InvoiceItemDetails).AsQueryable();

            if(!string.IsNullOrWhiteSpace(query.CustomerName))
            {
                invoice = invoice.Where(i=>i.CustomerName.ToLower().Contains(query.CustomerName.ToLower()));
            }

            var result = await invoice.ToListAsync();

            var skip = (query.PageNumber - 1) * query.PageSize;

            return result.Skip(skip).Take(query.PageSize).ToList();
        }

        public async Task<InvoiceMaster?> GetInvoiceByIdAsync(int Id)
        {
            return await _context.InvoiceMasters.Include(i => i.InvoiceItemDetails).FirstOrDefaultAsync(i => i.Id == Id);
        }

        public async Task<bool> UpdateInvoiceAsync(InvoiceMaster invoice)
        {
            _context.InvoiceMasters.Update(invoice);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteInvoiceAsync(int Id)
        {
            var invoice = await _context.InvoiceMasters.Include(i => i.InvoiceItemDetails).FirstOrDefaultAsync(i => i.Id == Id);

            if (invoice == null) return false;

            _context.InvoiceMasters.Remove(invoice);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> InvoiceNumberExistsAsync(string invoicenumber )
        {
            return await _context.InvoiceMasters.AnyAsync( i => i.InvoiceNumber == invoicenumber);
        }

        public async Task<bool> DeleteSingleInvoiceItemAsync(int invoicemasterid, int invoiceitemid)
        {
            var invoiceMaster = await _context.InvoiceMasters.Include(i => i.InvoiceItemDetails).FirstOrDefaultAsync(i => i.Id == invoicemasterid);

            if (invoiceMaster == null) return false;

            var invoiceItem = await _context.InvoiceItemDetails.FirstOrDefaultAsync(i => i.Id == invoiceitemid);

            if (invoiceItem == null) return false;

            _context.InvoiceItemDetails.Remove(invoiceItem);

            invoiceMaster.TotalAmount = invoiceMaster.InvoiceItemDetails.Where(i => i.Id != invoiceitemid).Sum(i => i.Total);

            await _context.SaveChangesAsync();

            return true;


        }
    }
}