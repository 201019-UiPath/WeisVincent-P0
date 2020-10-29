using Microsoft.EntityFrameworkCore;
using SufferShopDB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SufferShopDB.Repos.DBRepos
{
    public class ManagerDBRepo : IManagerRepo
    {
        private readonly SufferShopContext context;

        public ManagerDBRepo(SufferShopContext context)
        {
            this.context = context;
        }


        public void AddManagerAsync(Manager manager)
        {
            context.Managers.AddAsync(manager);
            context.SaveChangesAsync();
        }

        public Task<List<Manager>> GetAllManagersAsync()
        {
            return context.Managers.Where(m => m.Id != null).ToListAsync();
        }

        public Task<Manager> GetManagerByEmailAsync(string email)
        {
            return context.Managers.Where(m => m.Id != null && m.Email == email).FirstAsync();
        }
    }
}
