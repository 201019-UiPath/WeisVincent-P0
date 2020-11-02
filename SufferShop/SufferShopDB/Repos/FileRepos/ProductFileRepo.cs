using SufferShopDB.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SufferShopDB.Repos.FileRepos
{
    public class ProductFileRepo : IProductRepo
    {

        const string filepathProducts = "SufferShopDB/SampleData/Products.txt";

        public void AddNewProductToStock(int newProductId, int locationId)
        {
            throw new NotImplementedException();
        }

        public Task<List<InventoryLineItem>> GetAllInventoryEntriesAtLocationAsync(int locationID)
        {
            throw new NotImplementedException();
        }

        public List<OrderLineItem> GetOrderedProductsInAnOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderLineItem>> GetOrderedProductsInAnOrderAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public void RemoveProductAtLocation(int removedProductId, int locationId)
        {
            throw new NotImplementedException();
        }
    }
}
