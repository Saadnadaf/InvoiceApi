using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using api.Models;
namespace api.DTO
{
    public class CreateInvoiceMasterDTO
    {
        [JsonPropertyName("InvoiceNumber")]
        public string InvoiceNumber { get; set; }

        [JsonPropertyName("CustomerName")]
        public string CustomerName { get; set; }

        [JsonPropertyName("InvoiceDate")]
        public DateTime InvoiceDate { get; set; }
        
        [JsonPropertyName("InvoiceItems")]
        public List<CreateInvoiceItemDTO> InvoiceItemDetails {get; set;} = new List<CreateInvoiceItemDTO>();
        
    }
}