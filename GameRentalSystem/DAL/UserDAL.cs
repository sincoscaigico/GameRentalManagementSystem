using GameRentalSystem.DTO;
using System;
using System.Data.SqlClient;

namespace GameRentalSystem.DAL
{
    public class UserDAL
    {
        private readonly string connectionString =
            "Server=localhost;Database=GameRentalDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public UserDTO GetUserByUsername(
            string username
        )
        {
            UserDTO user = null;

            using (
                SqlConnection conn =
                new SqlConnection(connectionString)
            )
            {
                conn.Open();

                string query = @"
SELECT
    u.UserID,
    u.Username,
    u.Role,
    c.CustomerID,
    c.FullName
FROM Users u
LEFT JOIN Customers c
ON u.CustomerID = c.CustomerID
WHERE u.Username = @username";

                SqlCommand cmd =
                    new SqlCommand(
                        query,
                        conn
                    );

                cmd.Parameters.AddWithValue(
                    "@username",
                    username
                );

                SqlDataReader reader =
                    cmd.ExecuteReader();

                if (reader.Read())
                {
                    user = new UserDTO();

                    user.UserID =
                        Convert.ToInt32(
                            reader["UserID"]
                        );

                    user.Username =
                        reader["Username"]
                        .ToString();

                    user.Role =
                        reader["Role"]
                        .ToString();

                    if (
                        reader["CustomerID"]
                        != DBNull.Value
                    )
                    {
                        user.CustomerID =
                            Convert.ToInt32(
                                reader["CustomerID"]
                            );
                    }

                    if (
                        reader["FullName"]
                        != DBNull.Value
                    )
                    {
                        user.FullName =
                            reader["FullName"]
                            .ToString();
                    }
                }

                conn.Close();
            }

            return user;
        }
    }
}