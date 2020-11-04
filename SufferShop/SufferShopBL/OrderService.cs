using SufferShopDB.Models;
using SufferShopDB.Repos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SufferShopBL
{
    /// <summary>
    /// This class handles order-specific business logic for the SufferShop using a repository that implements IRepository.
    /// This includes logic that happens during the submission of a new order, such as updating inventory and adding a new order entry.
    /// </summary>
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

        public void RemoveLineItemFromLocationInventory(InventoryLineItem inventoryLineItem)
        {
            Repo.RemoveInventoryLineItemFromLocation(inventoryLineItem);
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
