using SufferShopDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SufferShopDB.Repos
{
    public interface ILocationRepo : IRepository
    {
        Task<List<Location>> GetAllLocationsAsync();
    }
}
