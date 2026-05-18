namespace GameRentalSystem.DTO
{
    public class GameDTO
    {
        public int GameID { get; set; }

        public string GameName { get; set; }

        public string Genre { get; set; }

        public string Platform { get; set; }

        public decimal RentalPrice { get; set; }

        public int StockQuantity { get; set; }

        public string Status { get; set; }
    }
}