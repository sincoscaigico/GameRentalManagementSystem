using System.Data;
using System.Data.SqlClient;

namespace GameRentalSystem.DAL
{
    public class RentalDAL
    {
        private readonly string connectionString =
            "Server=localhost;Database=GameRentalDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // =========================
        // GET RENTALS
        // =========================
        public DataTable GetRentals()
        {
            SqlConnection conn =
                new SqlConnection(connectionString);

            conn.Open();

            string query = @"
SELECT *
FROM Rentals
";

            SqlDataAdapter da =
                new SqlDataAdapter(
                    query,
                    conn
                );

            DataTable dt =
                new DataTable();

            da.Fill(dt);

            conn.Close();

            return dt;
        }

        // =========================
        // RETURN GAME
        // =========================
        public void ReturnGame(
            int rentalID
        )
        {
            SqlConnection conn =
                new SqlConnection(connectionString);

            conn.Open();

            string query = @"
UPDATE Rentals
SET Status = 'Returned'
WHERE RentalID = @RentalID
";

            SqlCommand cmd =
                new SqlCommand(
                    query,
                    conn
                );

            cmd.Parameters.AddWithValue(
                "@RentalID",
                rentalID
            );

            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}