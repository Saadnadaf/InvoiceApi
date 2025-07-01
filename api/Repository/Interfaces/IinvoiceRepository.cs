using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository.Interfaces
{
    public interface IinvoiceRepository
    {
        Task<InvoiceMaster> AddInvoiceAsync(InvoiceMaster invoice);
        Task<InvoiceMaster> GetInvoiceByIdAsync(int id);
        Task<List<InvoiceMaster>> GetAllInvoiceAsync();
        Task<bool> UpdateInvoiceAsync(InvoiceMaster invoice);
        Task<bool> DeleteInvoiceAsync(int id);
    }
}