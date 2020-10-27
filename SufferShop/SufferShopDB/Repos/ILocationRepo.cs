using SufferShopDB.Models;
using System.Collections.Generic;

namespace SufferShopDB.Repos
{
    public interface ILocationRepo : IRepository
    {
        List<Location> GetLocations();
    }
}
