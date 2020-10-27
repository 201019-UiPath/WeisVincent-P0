using SufferShopDB.Models;

namespace SufferShopDB.Repos
{
    public interface IManagerRepo : IRepository
    {


        /// <summary>
        /// This adds a manager entry to the data storage place.
        /// </summary>
        /// <param name="manager"></param>
        void AddManagerAsync(Manager manager);

        Manager GetManagerByEmail(string email);


    }
}
