using System.Data;
using GameRentalSystem.DAL;

namespace GameRentalSystem.BUS
{
    public class RentalBUS
    {
        RentalDAL dal =
            new RentalDAL();

        // =========================
        // GET RENTALS
        // =========================
        public DataTable GetRentals()
        {
            return dal.GetRentals();
        }

        // =========================
        // RENT GAME
        // =========================
        public void RentGame(
            string gameName,
            decimal total
        )
        {
            dal.RentGame(
                gameName,
                total
            );
        }

        // =========================
        // RETURN GAME
        // =========================
        public void ReturnGame(
            int rentalID,
            int gameID,
            int quantity
        )
        {
            dal.ReturnGame(
                rentalID,
                gameID,
                quantity
            );
        }
    }
}