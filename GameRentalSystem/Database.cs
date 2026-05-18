using System.Data.SqlClient;

namespace GameRentalSystem
{
    class Database
    {
        public static SqlConnection GetConnection()
        {
            string connString =
                @"Server=localhost;
                  Database=GameRentalDB;
                  Trusted_Connection=True;";

            return new SqlConnection(connString);
        }
    }
}