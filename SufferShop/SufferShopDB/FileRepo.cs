using Serilog;
using Serilog.Core;
using Serilog.Events;
using SufferShopModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace SufferShopDB
{
    /// <summary>
    /// Repository using files
    /// </summary>
    public class FileRepo : IRepository
    {
        string filepath = "HerosDB/HerosDataPlace/Heroes.txt";
        /// <summary>
        /// Adds hero to file
        /// </summary>
        /// <param name="hero"></param>
        public async void AddCustomerAsync(Customer customer)
        {
            using (FileStream fs = File.Create(filepath))
            {
                await JsonSerializer.SerializeAsync(fs, customer);
                System.Console.WriteLine("Customer is being written to file");
            }
        }
        /// <summary>
        /// Gets all heroes from file
        /// </summary>
        /// <returns></returns>
        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            List<Customer> allHeroes = new List<Customer>();
            using (FileStream fs = File.OpenRead(filepath))
            {
                try 
                { 
                    allHeroes.Add(await JsonSerializer.DeserializeAsync<Customer>(fs)); 
                }
                catch (Exception e)
                {
                    //TODO: Log this thing.
                    //Log.Write(new LogEvent(DateTimeOffset.Now, LogEventLevel.Error, e, ));
                }
            }
            return allHeroes;
        }
    }
}