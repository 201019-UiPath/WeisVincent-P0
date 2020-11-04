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

        public Task<List<Order>> GetAllOrdersForCustomerAsync(int customerID)
        {
            throw new NotImplementedException();
        }

        // TODO: Implement this
        public List<Order> GetCustomerOrderHistory(int CustomerID)
        {
            throw new NotImplementedException();
        }

        // TODO: Implement this
        public List<Order> GetAllOrdersForLocation(int locationID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAllOrdersForLocationAsync(int locationId)
        {
            throw new NotImplementedException();
        }

        public void RemoveInventoryLineItemsFromLocation(List<InventoryLineItem> lineItems)
        {
            throw new NotImplementedException();
        }

        public void AddOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public void RemoveInventoryLineItemFromLocation(InventoryLineItem lineItem)
        {
            throw new NotImplementedException();
        }
    }
}
