using SufferShopDB.Models;
using System;
using System.Collections.Generic;

namespace SufferShopDB.Repos.FileRepos
{
    class OrderFileRepo : IOrderRepo
    {
        const string filepathOrders = "SufferShopDB/SampleData/Orders.txt";


        public List<Order> GetCustomerOrderHistory(int CustomerID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetLocationOrderHistory(int locationID)
        {
            throw new NotImplementedException();
        }
    }
}
