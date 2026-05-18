using System.Data;
using System.Data.SqlClient;
using GameRentalSystem.DTO;

namespace GameRentalSystem.DAL
{
    public class AuthDAL
    {
        public bool Register(UserDTO user)
        {
            SqlConnection conn =
                Database.GetConnection();

            string query =
                @"INSERT INTO Users
                (Username, Password, Email)
                VALUES
                (@Username, @Password, @Email)";

            SqlCommand cmd =
                new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@Email", user.Email);

            conn.Open();

            int result =
                cmd.ExecuteNonQuery();

            conn.Close();

            if (result > 0)
            {
                InsertCustomer(user);
            }

            return result > 0;
        }

        private void InsertCustomer(UserDTO user)
        {
            SqlConnection conn =
                Database.GetConnection();

            string query =
                @"INSERT INTO Customers
                (FullName, Phone, Address, Email, Username)
                VALUES
                (@FullName, @Phone, @Address, @Email, @Username)";

            SqlCommand cmd =
                new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@FullName", user.FullName);
            cmd.Parameters.AddWithValue("@Phone", user.Phone);
            cmd.Parameters.AddWithValue("@Address", user.Address);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Username", user.Username);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public bool Login(string username, string password)
        {
            SqlConnection conn =
                Database.GetConnection();

            string query =
                @"SELECT COUNT(*)
                FROM Users
                WHERE Username = @Username
                AND Password = @Password";

            SqlCommand cmd =
                new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);

            conn.Open();

            int count =
                (int)cmd.ExecuteScalar();

            conn.Close();

            return count > 0;
        }
    }
}