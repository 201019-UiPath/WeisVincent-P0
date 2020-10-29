using SufferShopDB.Models;
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

        public void AddProductToStock(Product addedProduct, Location targetLocation)
        {
            repo.AddNewProductToStock(addedProduct, targetLocation);
        }



    }
}
