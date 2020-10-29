using SufferShopDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SufferShopDB.Repos
{
    public interface ICustomerRepo : IRepository
    {
        /// <summary>
        /// This adds a customer entry to the data storage place.
        /// </summary>
        /// <param name="customer"></param>
        void AddCustomerAsync(Customer customer);

        /// <summary>
        /// This gets all customers from data storage place
        /// </summary>
        /// <returns></returns>
        Task<List<Customer>> GetAllCustomersAsync();

        Task<List<Order>> GetAllOrdersForCustomer(Customer customer);


        Task<Customer> GetCustomerByEmailAsync(string email);
    }
}
