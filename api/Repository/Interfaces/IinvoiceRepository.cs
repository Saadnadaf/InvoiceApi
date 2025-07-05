using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Helpers;

namespace api.Repository.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<InvoiceMaster> AddInvoiceAsync(InvoiceMaster invoice);
        Task<InvoiceMaster?> GetInvoiceByIdAsync(int Id);
        Task<List<InvoiceMaster>> GetAllInvoiceAsync(QueryObject query);
        Task<bool> UpdateInvoiceAsync(InvoiceMaster invoice);
        Task<bool> DeleteInvoiceAsync(int Id);
        Task<bool> InvoiceNumberExistsAsync(string invoicenumber);
        Task<bool> DeleteSingleInvoiceItemAsync(int invoicemasterid,int invoiceitemid);
    }
}