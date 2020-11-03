using SufferShopDB.Models;
using SufferShopDB.Repos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace SufferShopBL
{
    public class CustomerService
    {
        readonly IRepository repo;

        public CustomerService(ref IRepository repo)
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
            Customer possibleExistingCustomer = repo.GetCustomerByEmail(newCustomer.Email);
            if (possibleExistingCustomer == null)
            {
                repo.AddCustomer(newCustomer);
                repo.SaveChanges();
            }
            else
            {
                throw new NullException(possibleExistingCustomer);
            }


        }

        public Customer GetCustomerByEmail(string newEmail)
        {
            return repo.GetCustomerByEmail(newEmail);
        }


        public List<Order> GetAllOrdersForCustomer(Customer customer)
        {
            return repo.GetAllOrdersForCustomer(customer.Id);
        }

        public List<Order> GetAllOrdersForCustomerAsync(Customer customer)
        {
            Task<List<Order>> getOrders = repo.GetAllOrdersForCustomerAsync(customer.Id);
            return getOrders.Result;
        }

    }
}
