using SufferShopDB.Models;
using SufferShopDB.Repos;
using System.Collections.Generic;

namespace SufferShopBL
{
    public class ManagerService
    {
        readonly IRepository repo;
        public ManagerService(ref IRepository repo)
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
            repo.SaveChanges();
        }

        public Manager GetManagerByEmail(string newEmail)
        {
            return repo.GetManagerByEmail(newEmail);
        }


    }
}
