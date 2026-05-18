using System.Data.Entity;
using GameRentalSystem.Models;

namespace GameRentalSystem
{
    public class GameRentalContext : DbContext
    {
        public GameRentalContext()
            : base("GameRentalDB")
        {

        }

        public DbSet<CustomerEF> Customers { get; set; }

        public DbSet<GameEF> Games { get; set; }
    }
}