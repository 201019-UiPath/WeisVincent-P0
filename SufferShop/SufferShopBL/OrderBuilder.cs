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
        private readonly OrderService OrderService;
        private readonly Customer CurrentCustomer;
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

        public StagedLineItem GetStagedLineItemForAffectedLineItemIfItExists(InventoryLineItem inventoryLineItem)
        {
            if (OrderCart.Exists(sli => sli.affectedInventoryLineItem == inventoryLineItem))
            {
                return OrderCart.FindLast(sli => sli.affectedInventoryLineItem == inventoryLineItem);
            }
            else return null;
            
        }

        public void DestageLineItem(int index)
        {
            StagedLineItem selectedStagedLineItem = OrderCart.ElementAt(index);

            if (selectedStagedLineItem.GetType() != typeof(StagedLineItem))
            {
                throw new Exception("What in the world happened in OrderBuilder?");
                //return;
            }

            OrderCart.RemoveAt(index);
        }

        

        public void StageProductForOrder(InventoryLineItem selection, int quantityOrdered)
        {
            StagedLineItem existingStagedLineItem = GetStagedLineItemForAffectedLineItemIfItExists(selection);
            if (existingStagedLineItem != null)
            {
                existingStagedLineItem.Quantity += quantityOrdered;
            } else AddLineItemToCart(selection, quantityOrdered);
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

                ProcessStagedLineItemOutOfInventory(lineItem);
            }
            return orderLineItems;
        }

        private void ProcessStagedLineItemOutOfInventory(StagedLineItem lineItem)
        {
            int newQuantity = lineItem.GetNewQuantityOfAffectedInventoryLineItem();
            if (newQuantity < 1)
            {
                SelectedLocationStock.Remove(lineItem.affectedInventoryLineItem);
            }
            else
            {
                SelectedLocationStock.Find(ili => ili.ProductId == lineItem.affectedInventoryLineItem.ProductId).ProductQuantity = newQuantity;
            }
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

            Order newOrder = new Order(CurrentCustomer, SelectedLocation, GetCurrentSubtotalOfCart(), GetTimeOrderIsPlaced());
            List<OrderLineItem> orderLineItems = ProcessOrderCartIntoOrderLineItems(ref OrderCart, newOrder);

            foreach (OrderLineItem lineItem in orderLineItems)
            {
                newOrder.AddLineItemToOrder(lineItem);
            }

            // TODO: Update Database with the new order, new order line items, and removal of Inventory line items
            OrderService.AddOrderToRepo(newOrder);
            //TODO: What to do about this line: OrderService.RemoveLineItemsFromLocationInventory(InventoryMarkedForRemoval);
        }

        private double GetCurrentSubtotalOfCart()
        {
            double totalPrice = 0.0;
            foreach (StagedLineItem lineItem in OrderCart)
            {
                totalPrice += lineItem.Product.Price;
            }
            return totalPrice;
        }

        public List<string> ReturnAvailableProductsAsStrings()
        {
            if (SelectedLocationStock.Count < 1)
            {
                Log.Error("The stock of the user's selected location was empty when used to display options. Can't successfully display non-existent options.");
            }
            List<string> availableItems = new List<string>(SelectedLocationStock.Count);

            foreach (InventoryLineItem entry in SelectedLocationStock)
            {
                Product product = entry.Product;
                int productQuantity;
                if (OrderCart.Exists(sli => sli.affectedInventoryLineItem == entry))
                {
                    productQuantity = OrderCart.FindLast(sli => sli.affectedInventoryLineItem == entry).GetNewQuantityOfAffectedInventoryLineItem();
                } else productQuantity = entry.ProductQuantity;
                string productType = Enum.GetName(typeof(ProductType), product.TypeOfProduct);

                availableItems.Add($"{product.Name}: {product.Description} Part of our {productType} collection. Quantity: {productQuantity}");
            }

            return availableItems;
        }
    }
}
