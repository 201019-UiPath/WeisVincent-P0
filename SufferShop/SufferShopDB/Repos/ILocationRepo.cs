using SufferShopDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SufferShopDB.Repos
{
    public interface ILocationRepo
    {
        Task<List<Location>> GetAllLocationsAsync();

        List<InventoryLineItem> GetAllInventoryLineItemsAtLocation(int locationId);

        Task<List<InventoryLineItem>> GetAllInventoryLineItemsAtLocationAsync(int locationId);

        void UpdateInventoryLineItem(InventoryLineItem lineItem);

    }
}
