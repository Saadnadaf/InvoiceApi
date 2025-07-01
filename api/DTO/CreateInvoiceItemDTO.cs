using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using System.Text.Json.Serialization;

namespace api.DTO
{
    public class CreateInvoiceItemDTO
    {   
        [JsonPropertyName("ProductName")]
        public string ProductName { get; set; }

        [JsonPropertyName("Quantity")]
        public int Quantity { get; set; }
        
        [JsonPropertyName("UnitPrice")]
        public decimal UnitPrice { get; set; }
    }
}