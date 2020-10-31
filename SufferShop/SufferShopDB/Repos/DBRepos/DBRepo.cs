using Microsoft.EntityFrameworkCore;
using Serilog;
using SufferShopDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SufferShopDB.Repos.DBRepos
{
    public class DBRepo : IRepository
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

        public Task<List<Order>> GetAllOrdersForCustomer(int customerId)
        {
            return context.Orders.Where(o => o.CustomerId == customerId).ToListAsync();
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
            Task<Manager> managerWithEmail;
            try
            {
                managerWithEmail = context.Managers.Where(m => m.Email == email).FirstAsync();
            } catch (ArgumentNullException e)
            {
                Log.Error(e.Message);
            } finally
            {
                managerWithEmail = null;
            }

            return managerWithEmail;
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

        #region Product methods
        public void AddNewProductToStock(int newProductId, int locationId)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveProductAtLocation(int removedProduct, int locationId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<InventoryLineItem>> GetAllProductsAtLocation(int locationID)
        {
            return context.InventoryLineItems.Where(ie => ie.LocationID == locationID).ToListAsync();
        }
        #endregion




        public Task<List<OrderLineItem>> GetOrderedProductsInAnOrder(int orderId)
        {
            return context.OrderLineItems.Where(op => op.OrderId == orderId).ToListAsync();
        }

        public Task<List<InventoryLineItem>> GetInventoryEntriesAtLocationAsync(int locationId)
        {
            return context.InventoryLineItems.Where(ie => ie.LocationID == locationId).ToListAsync();
        }


    }
}
