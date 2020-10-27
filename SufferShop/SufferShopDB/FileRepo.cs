using SufferShopModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace SufferShopDB
{
    /// <summary>
    /// Repository using files
    /// </summary>
    public class FileRepo : IRepository
    {


        const string filepathCustomers = "SufferShopDB/SampleData/Customers.txt";
        const string filepathManagers = "SufferShopDB/SampleData/Managers.txt";
        const string filepathOrders = "SufferShopDB/SampleData/Orders.txt";
        const string filepathProducts = "SufferShopDB/SampleData/Products.txt";
        const string filepathLocationStock = "SufferShopDB/SampleData/LocationStock.txt";


        /// <summary>
        /// Adds customer to file
        /// </summary>
        /// <param name="customer"></param>
        public async void AddCustomerAsync(Customer customer)
        {
            using (FileStream fs = File.Create(filepathCustomers))
            {
                await JsonSerializer.SerializeAsync(fs, customer);
                Console.WriteLine("Customer is being written to file");
            }
        }

        public async void AddManagerAsync(Manager manager)
        {
            using (FileStream fs = File.Create(filepathManagers))
            {
                await JsonSerializer.SerializeAsync(fs, manager);
                Console.WriteLine("Customer is being written to file");
            }
        }

        public void AddNewProductsToStock(List<Product> newProduct)
        {
            throw new NotImplementedException();
        }

        public void AddNewProductsToStock(List<Product> newProduct, int locationID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all customers from file
        /// </summary>
        /// <returns></returns>
        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            List<Customer> allHeroes = new List<Customer>();
            using (FileStream fs = File.OpenRead(filepathCustomers))
            {
                try
                {
                    allHeroes.Add(await JsonSerializer.DeserializeAsync<Customer>(fs));
                }
                catch (Exception e)
                {
                    //TODO: Log this thing.
                    //Log.Write(new LogEvent(DateTimeOffset.Now, LogEventLevel.Error, e, ));
                }
            }
            return allHeroes;
        }



        public List<Product> GetAllProductStockAtLocation(int locationID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCustomerOrderHistory(int CustomerID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetLocationOrderHistory(int locationID)
        {
            throw new NotImplementedException();
        }

        public List<Location> GetLocations()
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }


        public void RemoveProductsAtLocation(List<Product> removedProducts, int locationID)
        {
            throw new NotImplementedException();
        }
    }
}