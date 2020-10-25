using SufferShopDB;
using SufferShopModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SufferShopBL
{
    public class SufferShopBL
    {

        IRepository repo = new FileRepo();


        public List<Customer> GetAllCustomers()
        {
            Task<List<Customer>> getCustomers = repo.GetAllCustomersAsync();
            
            return getCustomers.Result;

        }



    }
}
