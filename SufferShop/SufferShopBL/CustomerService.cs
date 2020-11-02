using SufferShopDB.Models;
using SufferShopDB.Repos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SufferShopBL
{
    public class CustomerService
    {
        readonly IRepository repo;

        public CustomerService(IRepository repo)
        {
            this.repo = repo;
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> getCustomers = repo.GetAllCustomers();

            return getCustomers;
        }

        public void AddCustomerToRepo(Customer newCustomer)
        {
            repo.AddCustomer(newCustomer);
            repo.SaveChanges();
        }

        public Customer GetCustomerByEmail(string newEmail)
        {
            return repo.GetCustomerByEmail(newEmail);
        }

        public List<Order> GetAllOrdersForCustomerAsync(Customer customer)
        {
            return repo.GetAllOrdersForCustomerAsync(customer.Id).Result;
        }

    }
}
