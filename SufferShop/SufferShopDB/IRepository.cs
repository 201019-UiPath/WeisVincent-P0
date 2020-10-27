using System.Collections.Generic;
using System.Threading.Tasks;

namespace SufferShopDB
{
    /// <summary>
    /// Data access interface for hero stuff
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// This adds a customer entry to the data storage place.
        /// </summary>
        /// <param name="customer"></param>
        void AddCustomerAsync(Customer customer);


        /// <summary>
        /// This adds a manager entry to the data storage place.
        /// </summary>
        /// <param name="manager"></param>
        void AddManagerAsync(Manager manager);



        /// <summary>
        /// This gets all customers from data storage place
        /// </summary>
        /// <returns></returns>
        Task<List<Customer>> GetAllCustomersAsync();

        /// <summary>
        /// This gets the order history of a specific location, specified by that locations ID.
        /// </summary>
        /// <param name="locationID"></param>
        /// <returns></returns>
        List<Order> GetLocationOrderHistory(int locationID);

        /// <summary>
        /// This gets the order history of a specific customer, specified by that customer's ID.
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        List<Order> GetCustomerOrderHistory(int CustomerID);


        List<Product> GetAllProductStockAtLocation(int locationID);

        User GetUserByEmail(string email);

        List<Location> GetLocations();

        void AddNewProductsToStock(List<Product> newProduct, int locationID);

        void RemoveProductsAtLocation(List<Product> removedProducts, int locationID);





    }
}