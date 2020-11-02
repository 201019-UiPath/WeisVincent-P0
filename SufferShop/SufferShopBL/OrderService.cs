using SufferShopDB.Models;
using SufferShopDB.Repos;
using SufferShopLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SufferShopBL
{
    public class OrderService
    {
        readonly IRepository Repo;

        
        public OrderService(ref IRepository repo)
        {
            Repo = repo;
        }



        
        public void UpdateLineItemsInLocationInventory()
        {

            Repo.SaveChanges();
        }

        public void RemoveLineItemsFromLocationInventory(List<InventoryLineItem> inventoryLineItems)
        {
            Repo.RemoveInventoryLineItemsFromLocation(inventoryLineItems);
            Repo.SaveChanges();
        }

        public void AddOrderToRepo(Order order)
        {
            Repo.AddOrder(order);
            Repo.SaveChanges();
        }


        public List<OrderLineItem> GetAllProductsInOrder(Order order)
        {
            return Repo.GetOrderedProductsInAnOrder(order.Id);
        }

        public Task<List<OrderLineItem>> GetAllProductsInOrderAsync(Order order)
        {
            return Repo.GetOrderedProductsInAnOrderAsync(order.Id);
        }


    }
}
