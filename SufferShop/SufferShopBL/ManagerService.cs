using SufferShopDB.Repos;

namespace SufferShopBL
{
    public class ManagerService
    {
        IManagerRepo repo;
        public ManagerService(IManagerRepo repo)
        {
            this.repo = repo;
        }




    }
}
