using SufferShopDB.Models;
using SufferShopDB.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SufferShopBL
{
    public class LocationService
    {
        readonly ILocationRepo repo;

        public LocationService(ILocationRepo repo)
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
