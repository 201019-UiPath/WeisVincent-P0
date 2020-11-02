using SufferShopDB.Models;
using SufferShopDB.Repos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SufferShopBL
{
    public class ManagerService
    {
        readonly IManagerRepo repo;
        public ManagerService(IManagerRepo repo)
        {
            this.repo = repo;
        }

        public List<Manager> GetAllManagers()
        {
            List<Manager> getManagers = repo.GetAllManagers();

            return getManagers;

        }

        public void AddManager(Manager newManager)
        {
            repo.AddManager(newManager);
        }

        public Manager GetManagerByEmail(string newEmail)
        {
            return repo.GetManagerByEmail(newEmail);
        }


    }
}
