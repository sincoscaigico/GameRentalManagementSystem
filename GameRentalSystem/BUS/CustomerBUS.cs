using System.Data;
using GameRentalSystem.DAL;

namespace GameRentalSystem.BUS
{
    public class CustomerBUS
    {
        CustomerDAL dal =
            new CustomerDAL();

        public DataTable GetCustomers()
        {
            return dal.GetCustomers();
        }
    }
}