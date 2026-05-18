using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace GameRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly string connectionString =
            "Server=localhost;Database=GameRentalDB;Trusted_Connection=True;TrustServerCertificate=True;";

        [HttpGet]
        public IActionResult GetGames()
        {
            List<object> games = new List<object>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Games";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    games.Add(new
                    {
                        GameID = reader["GameID"],
                        GameName = reader["GameName"],
                        Genre = reader["Genre"],
                        PricePerDay = reader["RentalPrice"],
                        StockQuantity = reader["StockQuantity"]
                    });
                }
            }

            return Ok(games);
        }
    }
}