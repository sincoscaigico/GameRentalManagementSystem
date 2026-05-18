using System.Data;
using GameRentalSystem.DAL;

namespace GameRentalSystem.BUS
{
    public class GameBUS
    {
        GameDAL dal =
            new GameDAL();

        // =========================
        // GET GAMES
        // =========================
        public DataTable GetGames()
        {
            return dal.GetGames();
        }

        // =========================
        // DELETE GAME
        // =========================
        public void DeleteGame(int gameID)
        {
            dal.DeleteGame(gameID);
        }

        // =========================
        // SEARCH GAME
        // =========================
        public DataTable SearchGames(
            string keyword
        )
        {
            return dal.SearchGames(keyword);
        }
    }
}