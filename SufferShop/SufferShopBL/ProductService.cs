using SufferShopDB.Repos;

namespace SufferShopBL
{
    class ProductService
    {


        IProductRepo repo;

        public ProductService(IProductRepo repo)
        {
            this.repo = repo;
        }


    }
}
