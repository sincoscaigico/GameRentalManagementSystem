using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameRentalSystem.Models
{
    [Table("Games")]
    public class GameEF
    {
        [Key]
        public int GameID { get; set; }

        public string GameName { get; set; }

        public string Genre { get; set; }

        public string Platform { get; set; }

        public decimal RentalPrice { get; set; }

        public int StockQuantity { get; set; }

        public string Status { get; set; }
    }
}