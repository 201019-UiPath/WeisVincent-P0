using SufferShopDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SufferShopDB.Repos
{
    public interface IManagerRepo : IRepository
    {


        /// <summary>
        /// This adds a manager entry to the data storage place.
        /// </summary>
        /// <param name="manager"></param>
        void AddManagerAsync(Manager manager);

        /// <summary>
        /// This gets all customers from data storage place
        /// </summary>
        /// <returns></returns>
        Task<List<Manager>> GetAllManagersAsync();

        Task<Manager> GetManagerByEmailAsync(string email);


    }
}
