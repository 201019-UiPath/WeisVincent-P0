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

        public LocationService(ref IRepository repo)
        {
            this.repo = repo;
        }

        public List<Location> GetAllLocations()
        {
            return repo.GetAllLocations();
        }

        public List<Location> GetAllLocationsAsync()
        {
            Task<List<Location>> getLocations = repo.GetAllLocationsAsync();
            return getLocations.Result;
        }

        public Task<List<InventoryLineItem>> GetAllProductsAtLocationAsync(Location location)
        {
            return repo.GetAllInventoryLineItemsAtLocationAsync(location.Id);
        }

        public List<InventoryLineItem> GetAllProductsStockedAtLocation(Location location)
        {
            return repo.GetAllInventoryLineItemsAtLocation(location.Id);
        }

        public List<Order> GetAllOrdersForLocation(Location location)
        {
            return repo.GetAllOrdersForLocation(location.Id);
        }

        public void AddInventoryLineItemInRepo(InventoryLineItem lineItem)
        {
            repo.AddInventoryLineItem(lineItem);
            repo.SaveChanges();
        }

        public void UpdateInventoryLineItemInRepo(InventoryLineItem lineItem)
        {
            if (lineItem.ProductQuantity < 1)
            {
                RemoveInventoryLineItemInRepo(lineItem);
                return;
            }
            repo.UpdateInventoryLineItem(lineItem);
            repo.SaveChanges();
        }

        public void RemoveInventoryLineItemInRepo(InventoryLineItem lineItem)
        {
            repo.RemoveInventoryLineItem(lineItem);
            repo.SaveChanges();
        }



        public List<string> GetInventoryStockAsStrings(List<InventoryLineItem> inventoryStock)
        {
            List<string> inventoryStockAsStrings = new List<string>(inventoryStock.Count);
            if (inventoryStock.Count < 1 || inventoryStock == null)
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

    }
}
