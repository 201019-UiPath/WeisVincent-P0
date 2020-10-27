using SufferShopDB.Repos;

namespace SufferShopBL
{
    public class ManagerUtilities
    {
        IManagerRepo repo;
        public ManagerUtilities(IManagerRepo repo)
        {
            this.repo = repo;
        }




    }
}
