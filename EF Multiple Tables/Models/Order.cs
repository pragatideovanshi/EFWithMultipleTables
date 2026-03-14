using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EFMultipleTables.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        // Foreign Key
        public int CustomersId { get; set; }

        [ForeignKey("CustomersId")]
        public Customer Customer { get; set; }
    }
}