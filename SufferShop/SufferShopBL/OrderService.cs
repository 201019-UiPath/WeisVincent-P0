using SufferShopDB.Models;
using SufferShopDB.Repos;
using SufferShopLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SufferShopBL
{
    public class OrderService
    {
        readonly IRepository Repo;

        public struct StagedLineItem
        {
            public InventoryLineItem affectedInventoryLineItem;

            public Product Product;
            public int Quantity;
            public StagedLineItem(Product product, int quantity, InventoryLineItem affectedInventoryLineItem)
            {
                Product = product;
                Quantity = quantity;
                this.affectedInventoryLineItem = affectedInventoryLineItem;
            }

            public int GetNewQuantityOfAffectedInventoryLineItem()
            {
                return affectedInventoryLineItem.ProductQuantity - Quantity;
            }

        }



        private Customer CurrentCustomer;

        private readonly LocationService LocationService;
        private readonly Location SelectedLocation;
        public List<InventoryLineItem> SelectedLocationStock;
        public List<InventoryLineItem> InventoryMarkedForRemoval;

        public List<StagedLineItem> OrderCart;

        public OrderService(Customer customer, LocationService locationService, Location selectedLocation, IRepository repo)
        {
            Repo = repo;
            
            CurrentCustomer = customer;

            LocationService = locationService;
            SelectedLocation = selectedLocation;
            SelectedLocationStock = LocationService.GetAllProductsAtLocationAsync(SelectedLocation).Result;

            InventoryMarkedForRemoval = new List<InventoryLineItem>();
            OrderCart = new List<StagedLineItem>();

        }



        public void DestageLineItem(int index)
        {
            StagedLineItem selectedStagedLineItem = OrderCart.ElementAt(index);

            if (selectedStagedLineItem.GetType() != typeof(StagedLineItem))
            {
                throw new Exception("What in the world happened in OrderBuilder?");
                //return;
            }

            InventoryLineItem ReturnedItem = selectedStagedLineItem.affectedInventoryLineItem;
            SelectedLocationStock.Add(ReturnedItem);

            OrderCart.RemoveAt(index);
        }

        public void StageProductForOrder(InventoryLineItem selection, int quantityOrdered)
        {
            MarkProductForRemovalFromStock(selection);
            AddLineItemToCart(selection, quantityOrdered);
        }

        public void StageProductForOrder(InventoryLineItem selection)
        {
            StageProductForOrder(selection, 1);
        }


        private void AddLineItemToCart(InventoryLineItem selection, int quantityOrdered)
        {

            StagedLineItem newLineItem = new StagedLineItem(selection.Product, quantityOrdered, selection);
            OrderCart.Add(newLineItem);
        }

        private void MarkProductForRemovalFromStock(InventoryLineItem selection)
        {
            if (!SelectedLocationStock.Contains(selection))
            {
                throw new Exception("Couldn't find an Inventory Line Item matching the user's selection.");
                //return;
            }

            InventoryMarkedForRemoval.Add(selection);
            SelectedLocationStock.Remove(selection);
        }


        public List<string> GetOrderCartAsStrings()
        {
            List<string> OrderCartAsStrings = new List<string>(OrderCart.Count);
            if (OrderCart.Count < 1)
            {
                return OrderCartAsStrings;
            }

            Console.WriteLine("So far you've ordered:");
            foreach (StagedLineItem entry in OrderCart)
            {
                OrderCartAsStrings.Add($"{entry.Quantity} of {entry.Product.Name}");
            }

            return OrderCartAsStrings;
        }


        private List<OrderLineItem> ProcessOrderCartIntoOrderLineItems(ref List<StagedLineItem> orderCart, Order order)
        {
            List<OrderLineItem> orderLineItems = new List<OrderLineItem>(orderCart.Count);
            foreach (StagedLineItem lineItem in orderCart)
            {
                OrderLineItem newOrderLineItem = new OrderLineItem(order, lineItem.Product, lineItem.Quantity);
                orderLineItems.Add(newOrderLineItem);
            }
            return orderLineItems;
        }

        private double GetCurrentSubtotalOfCart(ref List<StagedLineItem> orderCart)
        {
            double totalPrice = 0.0;
            foreach (StagedLineItem lineItem in OrderCart)
            {
                totalPrice += lineItem.Product.Price;
            }
            return totalPrice;
        }

        private double GetTimeOrderIsPlaced()
        {
            DateTime currentTime = DateTime.Now;
            double currentTimePOSIX = DateTimeUtility.GetUnixEpochAsDouble(currentTime);
            return currentTimePOSIX;
        }

        public void BuildAndSubmitOrder()
        {
            //TODO: Create new Order, process the updated inventory list, and Add new OrderLineItems to reflect what's in the order.

            Order newOrder = new Order(CurrentCustomer, SelectedLocation, GetCurrentSubtotalOfCart(ref OrderCart), GetTimeOrderIsPlaced());
            List<OrderLineItem> orderLineItems = ProcessOrderCartIntoOrderLineItems(ref OrderCart, newOrder);

            foreach(OrderLineItem lineItem in orderLineItems)
            {
                newOrder.AddLineItemToOrder(lineItem);
            }

            // TODO: Update Database with the new order, new order line items, and removal of Inventory line items
            AddOrderToRepo(newOrder);
            RemoveLineItemsFromLocationInventory(InventoryMarkedForRemoval);
            Repo.SaveChanges();
        }

        private void RemoveLineItemsFromLocationInventory(List<InventoryLineItem> inventoryLineItems)
        {
            Repo.RemoveInventoryLineItemsFromLocation(inventoryLineItems);
        }

        private void AddOrderToRepo(Order order)
        {
            Repo.AddOrder(order);
        }

    }
}
