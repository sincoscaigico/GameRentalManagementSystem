using GameRentalSystem.DAL;
using GameRentalSystem.DTO;

namespace GameRentalSystem.BUS
{
    public class AuthBUS
    {
        private AuthDAL dal =
            new AuthDAL();

        // =========================
        // REGISTER
        // =========================
        public bool Register(
            UserDTO user
        )
        {
            // VALIDATION
            if (
                user.Username == "" ||
                user.Password == "" ||
                user.FullName == ""
            )
            {
                return false;
            }

            return dal.Register(user);
        }

        // =========================
        // LOGIN
        // =========================
        public bool Login(
            string username,
            string password
        )
        {
            // VALIDATION
            if (
                username == "" ||
                password == ""
            )
            {
                return false;
            }

            return dal.Login(
                username,
                password
            );
        }
    }
}