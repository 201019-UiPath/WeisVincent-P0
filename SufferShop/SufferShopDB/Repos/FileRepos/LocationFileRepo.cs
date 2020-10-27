using SufferShopDB.Models;
using System;
using System.Collections.Generic;

namespace SufferShopDB.Repos.FileRepos
{
    class LocationFileRepo : ILocationRepo
    {
        const string filepathLocations = "SufferShopDB/SampleData/Locations.txt";
        const string filepathLocationStock = "SufferShopDB/SampleData/LocationStock.txt";


        public List<Location> GetLocations()
        {
            throw new NotImplementedException();
        }



    }
}
