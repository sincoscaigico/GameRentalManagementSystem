namespace GameRentalSystem.DTO
{
    public class RentalDTO
    {
        public int RentalID
        {
            get;
            set;
        }

        public int CustomerID
        {
            get;
            set;
        }

        public int EmployeeID
        {
            get;
            set;
        }

        public int GameID
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }

        public decimal Price
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }
    }
}