using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Test_Assignment.Models
{
    public class Invoices
    {
        [Key]
        public int InvoiceID { get; set; }
        public string CustomerName { get; set; }

        // Navigation property (1 invoice → many items)
        public ICollection<InvoiceItems> InvoiceItems { get; set; }
    }

    public class InvoiceItems
    {
        [Key]
        public int ItemID { get; set; }
        public int InvoiceID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // Navigation property (each item belongs to one invoice)
        [JsonIgnore]
        public Invoices Invoice { get; set; }
    }
}
