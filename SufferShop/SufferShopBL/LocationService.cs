using SufferShopDB.Models;
using SufferShopDB.Repos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SufferShopBL
{
    public class LocationService
    {
        readonly IRepository repo;

        public LocationService(IRepository repo)
        {
            this.repo = repo;
        }

        public List<Location> GetAllLocations()
        {
            Task<List<Location>> getLocations = repo.GetAllLocationsAsync();
            return getLocations.Result;
        }

        public Task<List<InventoryLineItem>> GetAllProductsAtLocationAsync(Location location)
        {
            return repo.GetAllInventoryLineItemsAtLocationAsync(location.Id);
        }

        public List<InventoryLineItem> GetAllProductsAtLocation(Location location)
        {
            return repo.GetAllInventoryLineItemsAtLocation(location.Id);
        }

        public List<Order> GetAllOrdersForLocation(Location location)
        {
            return repo.GetAllOrdersForLocation(location.Id);
        }

        public List<string> GetInventoryStockAsStrings(List<InventoryLineItem> inventoryStock)
        {
            List<string> inventoryStockAsStrings = new List<string>(inventoryStock.Count);
            if (inventoryStock.Count < 1)
            {
                return inventoryStockAsStrings;
            }

            Console.WriteLine("So far you've ordered:");
            foreach (InventoryLineItem entry in inventoryStock)
            {
                inventoryStockAsStrings.Add($"{entry.ProductQuantity} of {entry.Product.Name}");
            }

            return inventoryStockAsStrings;
        }

        public void UpdateInventoryLineItemInRepo(InventoryLineItem lineItem)
        {
            repo.UpdateInventoryLineItem(lineItem);
            repo.SaveChanges();
        }
    }
}
