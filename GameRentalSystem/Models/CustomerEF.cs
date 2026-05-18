using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameRentalSystem.Models
{
    [Table("Customers")]
    public class CustomerEF
    {
        [Key]
        public int CustomerID { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Username { get; set; }
    }
}