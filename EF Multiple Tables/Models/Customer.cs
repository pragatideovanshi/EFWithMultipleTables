using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EFMultipleTables.Models
{
    public class Customer
    {
        [Key]
        public int CustomersId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        // Navigation property (1 → many)
        //[JsonIgnore]
        public ICollection<Order> Orders { get; set; }
    }
}