using SufferShopDB.Models;
using System.Collections.Generic;

namespace SufferShopDB.Repos
{
    public interface IProductRepo : IRepository
    {

        void AddNewProductToStock(Product newProduct, Location location);

        void RemoveProductsAtLocation(List<Product> removedProducts, Location location);








        List<Product> GetAllProductStockAtLocation(int locationID);


    }
}
