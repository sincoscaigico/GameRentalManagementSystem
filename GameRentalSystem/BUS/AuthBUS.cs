using GameRentalSystem.DAL;
using GameRentalSystem.DTO;

namespace GameRentalSystem.BUS
{
    public class AuthBUS
    {
        AuthDAL dal =
            new AuthDAL();

        public bool Register(UserDTO user)
        {
            return dal.Register(user);
        }

        public bool Login(string username, string password)
        {
            return dal.Login(username, password);
        }
    }
}