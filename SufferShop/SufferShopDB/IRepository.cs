using SufferShopModels;
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
        /// Adds hero to data storage place
        /// </summary>
        /// <param name="customer"></param>
        void AddCustomerAsync(Customer customer);
        /// <summary>
        /// Gets all heros from data storage place
        /// </summary>
        /// <returns></returns>
        Task<List<Customer>> GetAllCustomersAsync();

    }
}