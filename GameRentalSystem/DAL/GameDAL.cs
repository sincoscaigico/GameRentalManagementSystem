using System.Data;
using System.Data.SqlClient;

namespace GameRentalSystem.DAL
{
    public class GameDAL
    {
        // =========================
        // GET ALL GAMES
        // =========================
        public DataTable GetGames()
        {
            SqlConnection conn =
                Database.GetConnection();

            conn.Open();

            string query =
                @"SELECT
                    GameID,
                    GameName,
                    Genre,
                    Platform,
                    RentalPrice,
                    StockQuantity,
                    Status
                  FROM Games";

            SqlDataAdapter da =
                new SqlDataAdapter(query, conn);

            DataTable dt =
                new DataTable();

            da.Fill(dt);

            conn.Close();

            return dt;
        }

        // =========================
        // DELETE GAME
        // =========================
        public void DeleteGame(int gameID)
        {
            SqlConnection conn =
                Database.GetConnection();

            conn.Open();

            string query =
                "DELETE FROM Games WHERE GameID=@GameID";

            SqlCommand cmd =
                new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue(
                "@GameID",
                gameID
            );

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        // =========================
        // SEARCH GAME
        // =========================
        public DataTable SearchGames(
            string keyword
        )
        {
            SqlConnection conn =
                Database.GetConnection();

            conn.Open();

            string query =
                @"SELECT
                    GameID,
                    GameName,
                    Genre,
                    Platform,
                    RentalPrice,
                    StockQuantity,
                    Status
                  FROM Games
                  WHERE GameName LIKE @Keyword";

            SqlCommand cmd =
                new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue(
                "@Keyword",
                "%" + keyword + "%"
            );

            SqlDataAdapter da =
                new SqlDataAdapter(cmd);

            DataTable dt =
                new DataTable();

            da.Fill(dt);

            conn.Close();

            return dt;
        }
    }
}