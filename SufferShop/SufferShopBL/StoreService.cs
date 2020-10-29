using SufferShopDB.Models;
using SufferShopDB.Repos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SufferShopBL
{
    class StoreService
    {
        readonly ILocationRepo repo;

        public StoreService(ILocationRepo repo)
        {
            this.repo = repo;
        }

        public List<Location> GetAllLocations()
        {
            Task<List<Location>> getLocations = repo.GetAllLocationsAsync();

            return getLocations.Result;

        }
    }
}
