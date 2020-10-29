using Microsoft.EntityFrameworkCore;
using SufferShopDB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SufferShopDB.Repos.DBRepos
{
    public class DBRepo : ICustomerRepo, IManagerRepo, ILocationRepo, IOrderRepo
    {

        private readonly SufferShopContext context;

        public DBRepo(SufferShopContext context)
        {
            this.context = context;
        }

        #region Customer Methods
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

        #endregion

        #region Manager Methods
        public void AddManagerAsync(Manager manager)
        {
            context.Managers.AddAsync(manager);
            context.SaveChangesAsync();
        }

        public Task<List<Manager>> GetAllManagersAsync()
        {
            return context.Managers.ToListAsync();
        }

        public Task<Manager> GetManagerByEmailAsync(string email)
        {
            return context.Managers.Where(m => m.Id != null && m.Email == email).FirstAsync();
        }

        #endregion


        //TODO: Implement everything under this
        public Task<List<Location>> GetAllLocationsAsync()
        {
            return context.Locations.ToListAsync();
        }

        public Task<List<Order>> GetCustomerOrderHistory(int CustomerId)
        {
            return context.Orders.Where(o => o.CustomerId == CustomerId).ToListAsync();
        }

        public List<Order> GetLocationOrderHistory(int locationID)
        {
            throw new System.NotImplementedException();
        }

        Task<List<Order>> IOrderRepo.GetLocationOrderHistory(int locationID)
        {
            throw new System.NotImplementedException();
        }



    }
}
