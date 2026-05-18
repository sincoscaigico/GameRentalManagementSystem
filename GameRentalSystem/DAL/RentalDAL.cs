using System;
using System.Data;
using System.Data.SqlClient;

namespace GameRentalSystem.DAL
{
    public class RentalDAL
    {
        // =========================
        // GET RENTALS
        // =========================
        public DataTable GetRentals()
        {
            SqlConnection conn =
                Database.GetConnection();

            conn.Open();

            string query =
                @"SELECT
                    RentalID,
                    CustomerID,
                    EmployeeID,
                    RentalDate,
                    Status
                  FROM Rentals";

            SqlDataAdapter da =
                new SqlDataAdapter(query, conn);

            DataTable dt =
                new DataTable();

            da.Fill(dt);

            conn.Close();

            return dt;
        }

        // =========================
        // RENT GAME
        // =========================
        public void RentGame(
            string gameName,
            decimal total
        )
        {
            int quantity = 1;

            SqlConnection conn =
                Database.GetConnection();

            conn.Open();

            // GET GAME ID
            string gameQuery =
                "SELECT GameID " +
                "FROM Games " +
                "WHERE GameName=@game";

            SqlCommand gameCmd =
                new SqlCommand(gameQuery, conn);

            gameCmd.Parameters.AddWithValue(
                "@game",
                gameName
            );

            int gameID =
                Convert.ToInt32(
                    gameCmd.ExecuteScalar()
                );

            // CHECK STOCK
            string stockQuery =
                "SELECT dbo.fn_CheckGameStock(@id)";

            SqlCommand stockCmd =
                new SqlCommand(stockQuery, conn);

            stockCmd.Parameters.AddWithValue(
                "@id",
                gameID
            );

            int stock =
                Convert.ToInt32(
                    stockCmd.ExecuteScalar()
                );

            if (stock < quantity)
            {
                conn.Close();

                throw new Exception(
                    "Game đã hết hàng!"
                );
            }

            // RENT GAME
            SqlCommand cmd =
                new SqlCommand(
                    "sp_RentGame",
                    conn
                );

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@CustomerID",
                1
            );

            cmd.Parameters.AddWithValue(
                "@EmployeeID",
                1
            );

            cmd.Parameters.AddWithValue(
                "@GameID",
                gameID
            );

            cmd.Parameters.AddWithValue(
                "@Quantity",
                quantity
            );

            cmd.Parameters.AddWithValue(
                "@Price",
                total
            );

            cmd.ExecuteNonQuery();

            // UPDATE STOCK
            SqlCommand cmdStock =
                new SqlCommand(
                    "sp_UpdateGameStock",
                    conn
                );

            cmdStock.CommandType =
                CommandType.StoredProcedure;

            cmdStock.Parameters.AddWithValue(
                "@GameID",
                gameID
            );

            cmdStock.Parameters.AddWithValue(
                "@Quantity",
                quantity
            );

            cmdStock.ExecuteNonQuery();

            conn.Close();
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
            SqlConnection conn =
                Database.GetConnection();

            conn.Open();

            // UPDATE RENTAL
            string rentalQuery =
                @"UPDATE Rentals
                  SET Status='Returned'
                  WHERE RentalID=@RentalID";

            SqlCommand rentalCmd =
                new SqlCommand(rentalQuery, conn);

            rentalCmd.Parameters.AddWithValue(
                "@RentalID",
                rentalID
            );

            rentalCmd.ExecuteNonQuery();

            // RETURN STOCK
            string stockQuery =
                @"UPDATE Games
                  SET StockQuantity =
                  StockQuantity + @Quantity
                  WHERE GameID=@GameID";

            SqlCommand stockCmd =
                new SqlCommand(stockQuery, conn);

            stockCmd.Parameters.AddWithValue(
                "@Quantity",
                quantity
            );

            stockCmd.Parameters.AddWithValue(
                "@GameID",
                gameID
            );

            stockCmd.ExecuteNonQuery();

            // AVAILABLE AGAIN
            string statusQuery =
                @"UPDATE Games
                  SET Status='Available'
                  WHERE GameID=@GameID
                  AND StockQuantity > 0";

            SqlCommand statusCmd =
                new SqlCommand(statusQuery, conn);

            statusCmd.Parameters.AddWithValue(
                "@GameID",
                gameID
            );

            statusCmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}