using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace GameRentalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : ControllerBase
    {
        private readonly string connectionString =
            "Server=localhost;Database=GameRentalDB;Trusted_Connection=True;TrustServerCertificate=True;";

        [HttpGet]
        public IActionResult GetRentals()
        {
            List<object> rentals = new List<object>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        r.RentalID,
                        c.FullName,
                        r.RentalDate,
                        r.ReturnDate,
                        r.TotalAmount,
                        r.Status
                    FROM Rentals r
                    JOIN Customers c
                    ON r.CustomerID = c.CustomerID";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    rentals.Add(new
                    {
                        RentalID = reader["RentalID"],
                        FullName = reader["FullName"],
                        RentalDate = reader["RentalDate"],
                        ReturnDate = reader["ReturnDate"],
                        TotalAmount = reader["TotalAmount"],
                        Status = reader["Status"]
                    });
                }
            }

            return Ok(rentals);
        }
    }
}