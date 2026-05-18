using System;
using System.Data.SqlClient;
using GameRentalSystem.DTO;

namespace GameRentalSystem.DAL
{
    public class AuthDAL
    {
        // =========================
        // REGISTER
        // =========================
        public bool Register(UserDTO user)
        {
            SqlConnection conn =
                Database.GetConnection();

            conn.Open();

            SqlTransaction transaction =
                conn.BeginTransaction();

            try
            {
                // =========================
                // INSERT CUSTOMER
                // =========================
                string customerQuery =
                    @"
INSERT INTO Customers
(
    FullName,
    Phone,
    Address,
    Email,
    Username
)
OUTPUT INSERTED.CustomerID
VALUES
(
    @FullName,
    @Phone,
    @Address,
    @Email,
    @Username
)";

                SqlCommand customerCmd =
                    new SqlCommand(
                        customerQuery,
                        conn,
                        transaction
                    );

                customerCmd.Parameters.AddWithValue(
                    "@FullName",
                    user.FullName
                );

                customerCmd.Parameters.AddWithValue(
                    "@Phone",
                    user.Phone
                );

                customerCmd.Parameters.AddWithValue(
                    "@Address",
                    user.Address
                );

                customerCmd.Parameters.AddWithValue(
                    "@Email",
                    user.Email
                );

                customerCmd.Parameters.AddWithValue(
                    "@Username",
                    user.Username
                );

                int customerID =
                    Convert.ToInt32(
                        customerCmd.ExecuteScalar()
                    );

                // =========================
                // INSERT USER
                // =========================
                string userQuery =
                    @"
INSERT INTO Users
(
    Username,
    Password,
    Email,
    CustomerID
)
VALUES
(
    @Username,
    @Password,
    @Email,
    @CustomerID
)";

                SqlCommand userCmd =
                    new SqlCommand(
                        userQuery,
                        conn,
                        transaction
                    );

                userCmd.Parameters.AddWithValue(
                    "@Username",
                    user.Username
                );

                userCmd.Parameters.AddWithValue(
                    "@Password",
                    user.Password
                );

                userCmd.Parameters.AddWithValue(
                    "@Email",
                    user.Email
                );

                userCmd.Parameters.AddWithValue(
                    "@CustomerID",
                    customerID
                );

                int result =
                    userCmd.ExecuteNonQuery();

                transaction.Commit();

                conn.Close();

                return result > 0;
            }
            catch
            {
                transaction.Rollback();

                conn.Close();

                return false;
            }
        }

        // =========================
        // LOGIN
        // =========================
        public bool Login(
            string username,
            string password
        )
        {
            SqlConnection conn =
                Database.GetConnection();

            string query =
                @"
SELECT COUNT(*)
FROM Users
WHERE Username = @Username
AND Password = @Password";

            SqlCommand cmd =
                new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue(
                "@Username",
                username
            );

            cmd.Parameters.AddWithValue(
                "@Password",
                password
            );

            conn.Open();

            int count =
                (int)cmd.ExecuteScalar();

            conn.Close();

            return count > 0;
        }
    }
}