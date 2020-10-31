using SufferShopDB.Models;
using System;
using System.Collections.Generic;

namespace SufferShopDB.Repos.FileRepos
{
    public class ProductFileRepo : IProductRepo
    {

        const string filepathProducts = "SufferShopDB/SampleData/Products.txt";

        public void AddNewProductsToStock(List<Product> newProduct)
        {
            throw new NotImplementedException();
        }

        public void AddNewProductsToStock(List<Product> newProduct, int locationID)
        {
            throw new NotImplementedException();
        }

        public void RemoveProductsAtLocation(List<Product> removedProducts, int locationID)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProductStockAtLocation(int locationID)
        {
            throw new NotImplementedException();
        }

        public void AddNewProductToStock(int newProductId, int locationId)
        {
            throw new NotImplementedException();
        }

        public void RemoveProductAtLocation(List<Product> removedProducts, Location location)
        {
            throw new NotImplementedException();
        }
    }
}
