using SufferShopDB.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SufferShopDB.Repos.FileRepos
{
    class LocationFileRepo : ILocationRepo
    {
        const string filepathLocations = "SufferShopDB/SampleData/Locations.txt";
        const string filepathLocationStock = "SufferShopDB/SampleData/LocationStock.txt";

        public Task<List<Location>> GetAllLocationsAsync()
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAllOrdersForLocation(int locationId)
        {
            throw new NotImplementedException();
        }

        public Task<List<InventoryLineItem>> GetAllInventoryLineItemsAtLocationAsync(int locationId)
        {
            throw new NotImplementedException();
        }

        // TODO: Implement this
        public List<Location> GetLocations()
        {
            throw new NotImplementedException();
        }

        public List<InventoryLineItem> GetAllInventoryLineItemsAtLocation(int locationId)
        {
            throw new NotImplementedException();
        }

        public void UpdateInventoryLineItem(InventoryLineItem lineItem)
        {
            throw new NotImplementedException();
        }
    }
}
