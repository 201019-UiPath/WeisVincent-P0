using Microsoft.EntityFrameworkCore;
using SufferShopDB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SufferShopDB.Repos.DBRepos
{
    public class CustomerDBRepo : ICustomerRepo
    {

        private SufferShopContext context;

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
            return context.Customers.Where(x => x.ID != null).ToListAsync();
        }

        public Task<Customer> GetCustomerByEmail(string email)
        {
            return context.Customers.Where(c => c.ID != null && c.Email == email).FirstAsync();
        }
    }
}
