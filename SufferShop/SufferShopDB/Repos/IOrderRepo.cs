using SufferShopDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SufferShopDB.Repos
{
    interface IOrderRepo : IRepository
    {
        /// <summary>
        /// This gets the order history of a specific customer, specified by that customer's ID.
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        Task<List<Order>> GetCustomerOrderHistory(int CustomerID);


        /// <summary>
        /// This gets the order history of a specific location, specified by that locations ID.
        /// </summary>
        /// <param name="locationID"></param>
        /// <returns></returns>
        Task<List<Order>> GetLocationOrderHistory(int locationID);
    }
}
