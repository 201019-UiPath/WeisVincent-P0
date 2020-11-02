using SufferShopDB.Models;
using System.Collections.Generic;

namespace SufferShopDB.Repos
{
    /// <summary>
    /// Data access interface for hero stuff
    /// </summary>
    public interface IRepository : ICustomerRepo, ILocationRepo, IManagerRepo, IOrderRepo, IProductRepo
    {

        void SaveChangesAsync();

        void SaveChanges();
    }
}