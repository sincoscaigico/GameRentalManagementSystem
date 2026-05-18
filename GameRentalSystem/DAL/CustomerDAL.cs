using System.Data;
using System.Data.SqlClient;

namespace GameRentalSystem.DAL
{
    public class CustomerDAL
    {
        public DataTable GetCustomers()
        {
            SqlConnection conn =
                Database.GetConnection();

            conn.Open();

            string query =
                @"SELECT
                    CustomerID,
                    FullName,
                    Phone,
                    Email,
                    Address
                  FROM Customers";

            SqlDataAdapter da =
                new SqlDataAdapter(query, conn);

            DataTable dt =
                new DataTable();

            da.Fill(dt);

            conn.Close();

            return dt;
        }
    }
}