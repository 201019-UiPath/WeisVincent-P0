using Serilog;
using SufferShopDB.Models;
using SufferShopDB.Repos;
using SufferShopLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SufferShopBL
{

    //TODO: Refactor this entire stupid class
    public class OrderBuilder
    {
        OrderService OrderService;
        Customer CurrentCustomer;
        private readonly Location SelectedLocation;

        public List<StagedLineItem> OrderCart;

        public List<InventoryLineItem> SelectedLocationStock;

        public OrderBuilder(ref Customer currentCustomer, ref Location selectedLocation, ref IRepository repo)
        {
            OrderService = new OrderService(ref repo);
            
            CurrentCustomer = currentCustomer;
            SelectedLocation = selectedLocation;

            LocationService locationService = new LocationService(ref repo);
            SelectedLocationStock = locationService.GetAllProductsAtLocation(SelectedLocation);

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
            //SelectedLocationStock.Add(ReturnedItem);

            OrderCart.RemoveAt(index);
        }

        

        public void StageProductForOrder(InventoryLineItem selection, int quantityOrdered)
        {
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

            foreach (OrderLineItem lineItem in orderLineItems)
            {
                newOrder.AddLineItemToOrder(lineItem);
            }

            // TODO: Update Database with the new order, new order line items, and removal of Inventory line items
            OrderService.AddOrderToRepo(newOrder);
            //TODO: What to do about this line: OrderService.RemoveLineItemsFromLocationInventory(InventoryMarkedForRemoval);
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

        public List<string> ReturnAvailableItemsAsStrings()
        {
            if (SelectedLocationStock.Count < 1)
            {
                Log.Error("The stock of the user's selected location was empty when used to display options. Can't successfully display non-existent options.");
            }
            List<string> availableItems = new List<string>(SelectedLocationStock.Count);

            foreach (InventoryLineItem entry in SelectedLocationStock)
            {
                Product product = entry.Product;
                int productQuantity = entry.ProductQuantity;
                string productType = Enum.GetName(typeof(ProductType), product.TypeOfProduct);

                availableItems.Add($"{product.Name}: {product.Description} Part of our {productType} collection. Quantity: {productQuantity}");
            }

            return availableItems;
        }
    }
}
