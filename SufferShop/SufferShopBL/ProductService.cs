using SufferShopDB.Models;
using SufferShopDB.Repos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SufferShopBL
{
    public class ProductService
    {
        readonly IProductRepo repo;

        public ProductService(IProductRepo repo)
        {
            this.repo = repo;
        }

        public void AddProductToStock(Product addedProduct, Location targetLocation)
        {
            repo.AddNewProductToStock(addedProduct.Id, targetLocation.Id);
        }

        public List<InventoryLineItem> GetAllProductsAtLocation(Location location)
        {
            return repo.GetAllProductsAtLocation(location.Id).Result;
        }

        public Task<List<OrderLineItem>> GetAllProductsInOrderAsync(Order order)
        {
            return repo.GetOrderedProductsInAnOrder(order.Id);
        }

    }
}
