using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using api.Models;
using System.ComponentModel.DataAnnotations;
namespace api.DTO
{
    public class CreateInvoiceMasterDTO
    {
        [JsonPropertyName("InvoiceNumber")]
        [Required]
        [StringLength(50)]
        public string InvoiceNumber { get; set; } = string.Empty;

        [JsonPropertyName("CustomerName")]
        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [JsonPropertyName("InvoiceDate")]
        [Required]
        public DateTime InvoiceDate { get; set; }

        [JsonPropertyName("InvoiceItems")]
        [MinLength(1,ErrorMessage = "At least one invoice item is required")]
        public List<CreateInvoiceItemDTO> InvoiceItemDetails { get; set; } = new List<CreateInvoiceItemDTO>();
    }
}