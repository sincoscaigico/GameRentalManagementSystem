using System.Linq;
using System.Web.Http;

namespace GameRentalSystem.API
{
    public class GameApiDemo : ApiController
    {
        // =========================
        // GET ALL GAMES
        // =========================
        [HttpGet]
        public object GetGames()
        {
            GameRentalContext db =
                new GameRentalContext();

            var games =
                db.Games
                .Select(g => new
                {
                    g.GameID,
                    g.GameName,
                    g.Genre,
                    g.Platform,
                    g.RentalPrice,
                    g.StockQuantity,
                    g.Status
                })
                .ToList();

            return new
            {
                success = true,
                total = games.Count,
                data = games
            };
        }

        // =========================
        // GET CUSTOMERS
        // =========================
        [HttpGet]
        public object GetCustomers()
        {
            GameRentalContext db =
                new GameRentalContext();

            var customers =
                db.Customers
                .Select(c => new
                {
                    c.CustomerID,
                    c.FullName,
                    c.Phone,
                    c.Email
                })
                .ToList();

            return new
            {
                success = true,
                total = customers.Count,
                data = customers
            };
        }
    }
}