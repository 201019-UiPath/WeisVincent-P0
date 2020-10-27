using SufferShopDB.Models;
using SufferShopDB.Repos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SufferShopBL
{
    public class CustomerUtilities
    {

        ICustomerRepo repo;

        public CustomerUtilities(ICustomerRepo repo)
        {
            this.repo = repo;
        }

        public List<Customer> GetAllCustomers()
        {
            Task<List<Customer>> getCustomers = repo.GetAllCustomersAsync();

            return getCustomers.Result;

        }



    }
}
