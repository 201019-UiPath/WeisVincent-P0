using SufferShopDB.Models;
using SufferShopDB.Repos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SufferShopBL
{
    /// <summary>
    /// This class handles product-specific business logic for the SufferShop using a repository that implements IRepository.
    /// This includes adding new abstract product entries to the repository and getting the products in an order or at location.
    /// </summary>
    public class ProductService
    {
        readonly IRepository repo;

        public ProductService(ref IRepository repo)
        {
            this.repo = repo;
        }

        public void AddProductToStock(Product addedProduct, Location targetLocation)
        {
            repo.AddNewProductToStock(addedProduct.Id, targetLocation.Id);
            repo.SaveChanges();
        }

        public List<InventoryLineItem> GetAllProductsAtLocation(Location location)
        {
            return repo.GetAllInventoryLineItemsAtLocationAsync(location.Id).Result;
        }

        public List<OrderLineItem> GetAllProductsInOrder(Order order)
        {
            return repo.GetOrderedProductsInAnOrder(order.Id);
        }

        public Task<List<OrderLineItem>> GetAllProductsInOrderAsync(Order order)
        {
            return repo.GetOrderedProductsInAnOrderAsync(order.Id);
        }

        public List<Product> GetAllProducts()
        {
            return repo.GetAllProducts();
        }

        public void AddNewProduct(Product product)
        {
            repo.AddNewProduct(product);
            repo.SaveChanges();
        }

    }
}
