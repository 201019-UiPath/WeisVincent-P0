using SufferShopDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SufferShopDB.Repos
{
    public interface IOrderRepo
    {


        /// <summary>
        /// This adds an order entry to the data storage place.
        /// </summary>
        /// <param name="order"></param>
        void AddOrder(Order order);


        /// <summary>
        /// This gets the order history of a specific customer, specified by that customer's ID.
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        Task<List<Order>> GetCustomerOrderHistoryAsync(int customerID);


        /// <summary>
        /// This gets the order history of a specific location, specified by that locations ID, asynchronously.
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        Task<List<Order>> GetLocationOrderHistoryAsync(int locationId);

        /// <summary>
        /// This gets the order history of a specific location, specified by that locations ID.
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        List<Order> GetLocationOrderHistory(int locationID);

        void RemoveInventoryLineItemsFromLocation(List<InventoryLineItem> lineItems);


    }
}
