using Microsoft.EntityFrameworkCore;
using SufferShopDB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SufferShopDB.Repos.DBRepos
{
    public class CustomerDBRepo : ICustomerRepo
    {

        private readonly SufferShopContext context;

        public CustomerDBRepo(SufferShopContext context)
        {
            this.context = context;
        }


        public void AddCustomerAsync(Customer customer)
        {
            context.Customers.AddAsync(customer);
            context.SaveChangesAsync();
        }

        public Task<List<Customer>> GetAllCustomersAsync()
        {
            return context.Customers.ToListAsync();
        }

        public Task<List<Order>> GetAllOrdersForCustomer(Customer customer)
        {
            return context.Orders.Where(o => o.CustomerId == customer.Id).ToListAsync();
        }

        public Task<Customer> GetCustomerByEmailAsync(string email)
        {
            return context.Customers.Where(c => c.Email == email).FirstAsync();
        }
    }
}
