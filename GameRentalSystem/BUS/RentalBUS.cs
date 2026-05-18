using GameRentalSystem.DAL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace GameRentalSystem.BUS
{
    public class RentalBUS
    {
        private readonly string connectionString =
            "Server=localhost;Database=GameRentalDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // =========================
        // RENT GAME
        // =========================
        public void RentGame(
            int gameID,
            decimal total,
            int days
        )
        {
            using (
                SqlConnection conn =
                new SqlConnection(connectionString)
            )
            {
                conn.Open();

                // INSERT RENTAL
                string insertQuery = @"
INSERT INTO Rentals
(
    CustomerID,
    EmployeeID,
    RentalDate,
    ReturnDate,
    TotalAmount,
    Status
)
VALUES
(
    1,
    1,
    GETDATE(),
    DATEADD(day, @days, GETDATE()),
    @total,
    'Renting'
)";

                SqlCommand insertCmd =
                    new SqlCommand(
                        insertQuery,
                        conn
                    );

                insertCmd.Parameters.AddWithValue(
                    "@days",
                    days
                );

                insertCmd.Parameters.AddWithValue(
                    "@total",
                    total
                );

                insertCmd.ExecuteNonQuery();

                // UPDATE STOCK
                string updateQuery = @"
UPDATE Games
SET StockQuantity = StockQuantity - 1
WHERE GameID = @gameID";

                SqlCommand updateCmd =
                    new SqlCommand(
                        updateQuery,
                        conn
                    );

                updateCmd.Parameters.AddWithValue(
                    "@gameID",
                    gameID
                );

                updateCmd.ExecuteNonQuery();

                conn.Close();
            }
        }

        // =========================
        // GET RENTALS
        // =========================
        public DataTable GetRentals()
        {
            RentalDAL dal =
                new RentalDAL();

            return dal.GetRentals();
        }

        // =========================
        // RETURN GAME
        // =========================
        public void ReturnGame(
            int rentalID
        )
        {
            RentalDAL dal =
                new RentalDAL();

            dal.ReturnGame(rentalID);
        }
    }
}