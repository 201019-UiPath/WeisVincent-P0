using SufferShopModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SufferShopDB
{
    /// <summary>
    /// Sample data class for development purposes only, before proper database usage is implemented. 
    /// Should not be utilized in final build.
    /// </summary>
    public class SampleData : IRepository
    {

        List<Customer> CustomerTable = new List<Customer>();
        List<Manager> ManagerTable = new List<Manager>();
        List<Location> LocationTable = new List<Location>();
        List<Order> OrderTable = new List<Order>();
        List<Product> ProductTable = new List<Product>();


        public SampleData()
        {
            AddCustomerAsync(new Customer("Nick West", "nevanwest@west.com", "nevaniscool"));



        }




        public void AddCustomerAsync(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public void AddManagerAsync(Manager manager)
        {
            throw new System.NotImplementedException();
        }

        public void AddNewProductsToStock(List<Product> newProduct, int locationID)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Customer>> GetAllCustomersAsync()
        {
            throw new System.NotImplementedException();
        }

        public List<Product> GetAllProductStockAtLocation(int locationID)
        {
            throw new System.NotImplementedException();
        }

        public List<Order> GetCustomerOrderHistory(int CustomerID)
        {
            throw new System.NotImplementedException();
        }

        public List<Order> GetLocationOrderHistory(int locationID)
        {
            throw new System.NotImplementedException();
        }

        public List<Location> GetLocations()
        {
            throw new System.NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveProductsAtLocation(List<Product> removedProducts, int locationID)
        {
            throw new System.NotImplementedException();
        }
    }
}
