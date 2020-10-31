﻿using SufferShopDB.Models;
using SufferShopDB.Repos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SufferShopBL
{
    public class CustomerService
    {
        readonly ICustomerRepo repo;

        public CustomerService(ICustomerRepo repo)
        {
            this.repo = repo;
        }

        public List<Customer> GetAllCustomers()
        {
            Task<List<Customer>> getCustomers = repo.GetAllCustomersAsync();

            return getCustomers.Result;

        }

        public void AddCustomer(Customer newCustomer)
        {
            repo.AddCustomerAsync(newCustomer);
        }

        public Customer GetCustomerByEmail(string newEmail)
        {
            return repo.GetCustomerByEmailAsync(newEmail).Result;
        }

        public List<Order> GetAllOrdersForCustomer(Customer customer)
        {
            return repo.GetAllOrdersForCustomer(customer.Id).Result;
        }

    }
}
