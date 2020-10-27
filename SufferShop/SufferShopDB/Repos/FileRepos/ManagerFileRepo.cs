using SufferShopDB.Models;
using System;
using System.IO;
using System.Text.Json;

namespace SufferShopDB.Repos.FileRepos
{
    class ManagerFileRepo : IManagerRepo
    {

        const string filepathManagers = "SufferShopDB/SampleData/Managers.txt";

        public async void AddManagerAsync(Manager manager)
        {
            using (FileStream fs = File.Create(filepathManagers))
            {
                await JsonSerializer.SerializeAsync(fs, manager);
                Console.WriteLine("Customer is being written to file");
            }
        }

        public Manager GetManagerByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
