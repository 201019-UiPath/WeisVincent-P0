using SufferShopDB.Models;
using SufferShopDB.Repos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SufferShopBL
{
    public class ManagerService
    {
        IManagerRepo repo;
        public ManagerService(IManagerRepo repo)
        {
            this.repo = repo;
        }

        public List<Manager> GetAllManagers()
        {
            Task<List<Manager>> getCustomers = repo.GetAllManagersAsync();

            return getCustomers.Result;

        }

        public void AddManager(Manager newManager)
        {
            repo.AddManagerAsync(newManager);
        }

        public Manager GetManagerByEmail(string newEmail)
        {
            return repo.GetManagerByEmailAsync(newEmail).Result;
        }


    }
}
