using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace GameRentalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly string connectionString =
            "Server=localhost;Database=GameRentalDB;Trusted_Connection=True;TrustServerCertificate=True;";

        [HttpGet]
        public IActionResult GetCustomers()
        {
            List<object> customers = new List<object>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Customers";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    customers.Add(new
                    {
                        CustomerID = reader["CustomerID"],
                        FullName = reader["FullName"],
                        Phone = reader["Phone"],
                        Email = reader["Email"],
                        Address = reader["Address"]
                    });
                }
            }

            return Ok(customers);
        }
    }
}