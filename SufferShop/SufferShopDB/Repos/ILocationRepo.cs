using SufferShopDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SufferShopDB.Repos
{
    public interface ILocationRepo
    {
        Task<List<Location>> GetAllLocationsAsync();

        Task<List<InventoryLineItem>> GetInventoryEntriesAtLocationAsync(int locationId);
    }
}
