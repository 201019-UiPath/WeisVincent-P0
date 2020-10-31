﻿using SufferShopDB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace SufferShopDB.Repos.FileRepos
{
    public class CustomerFileRepo : ICustomerRepo
    {
        const string filepathCustomers = "SufferShopDB/SampleData/Customers.txt";



        /// <summary>
        /// Adds customer to file
        /// </summary>
        /// <param name="customer"></param>
        public async void AddCustomerAsync(Customer customer)
        {
            using (FileStream fs = File.Create(filepathCustomers))
            {
                await JsonSerializer.SerializeAsync(fs, customer);
                Console.WriteLine("Customer is being written to file");
            }
        }

        /// <summary>
        /// Gets all customers from file
        /// </summary>
        /// <returns></returns>
        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            List<Customer> allHeroes = new List<Customer>();
            using (FileStream fs = File.OpenRead(filepathCustomers))
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

        public Task<List<Order>> GetAllOrdersForCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
