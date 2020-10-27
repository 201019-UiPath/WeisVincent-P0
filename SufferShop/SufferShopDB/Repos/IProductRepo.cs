using SufferShopDB.Models;
using System.Collections.Generic;

namespace SufferShopDB.Repos
{
    public interface IProductRepo : IRepository
    {

        void AddNewProductsToStock(List<Product> newProduct, int locationID);

        void RemoveProductsAtLocation(List<Product> removedProducts, int locationID);








        List<Product> GetAllProductStockAtLocation(int locationID);


    }
}
