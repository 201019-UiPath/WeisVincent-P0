using SufferShopDB.Models;
using System.Collections.Generic;

namespace SufferShopDB.Repos
{
    interface IOrderRepo : IRepository
    {
        /// <summary>
        /// This gets the order history of a specific customer, specified by that customer's ID.
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        List<Order> GetCustomerOrderHistory(int CustomerID);


        /// <summary>
        /// This gets the order history of a specific location, specified by that locations ID.
        /// </summary>
        /// <param name="locationID"></param>
        /// <returns></returns>
        List<Order> GetLocationOrderHistory(int locationID);
    }
}
