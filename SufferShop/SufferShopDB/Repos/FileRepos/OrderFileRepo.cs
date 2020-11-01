using SufferShopDB.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SufferShopDB.Repos.FileRepos
{
    class OrderFileRepo : IOrderRepo
    {
        const string filepathOrders = "SufferShopDB/SampleData/Orders.txt";

        public void AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        // TODO: Implement this
        public List<Order> GetCustomerOrderHistory(int CustomerID)
        {
            throw new NotImplementedException();
        }

        // TODO: Implement this
        public List<Order> GetLocationOrderHistory(int locationID)
        {
            throw new NotImplementedException();
        }

        public void RemoveInventoryLineItemsFromLocation(List<InventoryLineItem> lineItems)
        {
            throw new NotImplementedException();
        }

        // TODO: Implement this
        Task<List<Order>> IOrderRepo.GetCustomerOrderHistoryAsync(int CustomerID)
        {
            throw new NotImplementedException();
        }

        // TODO: Implement this
        Task<List<Order>> IOrderRepo.GetLocationOrderHistoryAsync(int locationID)
        {
            throw new NotImplementedException();
        }
    }
}
