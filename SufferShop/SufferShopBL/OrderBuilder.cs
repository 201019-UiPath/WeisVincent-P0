using Serilog;
using SufferShopDB.Models;
using SufferShopDB.Repos;
using SufferShopLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SufferShopBL
{

    //TODO: Refactor this entire stupid class

    /// <summary>
    /// This class handles the creation and display of new orders and order carts for current users.
    /// It is in desperate need of simplification, but it manages locally staged line items and quantity computation 
    /// as well as storing relevant information until the customer submits their order.
    /// </summary>
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
            SelectedLocationStock = locationService.GetAllProductsStockedAtLocation(SelectedLocation);

            OrderCart = new List<StagedLineItem>();
        }

        public StagedLineItem GetStagedLineItemForAffectedLineItemIfItExists(InventoryLineItem inventoryLineItem)
        {
            Log.Logger.Information("Checking to see if an inventory line item has been added to the order cart already..");
            if (OrderCart.Exists(sli => sli.affectedInventoryLineItem == inventoryLineItem))
            {
                return OrderCart.FindLast(sli => sli.affectedInventoryLineItem == inventoryLineItem);
            }
            else return null;

        }

        public void DestageLineItem(int index)
        {
            Log.Logger.Information("Removing a staged line item from the user's order cart..");
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
                Log.Logger.Information("Changing the quantity of an existing line item in the order cart..");
                existingStagedLineItem.Quantity += quantityOrdered;
            }
            else AddLineItemToCart(selection, quantityOrdered);
        }

        public void StageProductForOrder(InventoryLineItem selection)
        {
            StageProductForOrder(selection, 1);
        }


        private void AddLineItemToCart(InventoryLineItem selection, int quantityOrdered)
        {
            Log.Logger.Information("Adding a staged line item to the user's order cart..");
            StagedLineItem newLineItem = new StagedLineItem(selection.Product, quantityOrdered, selection);
            OrderCart.Add(newLineItem);
        }

        // TODO: Move this to a UI class.
        public List<string> GetOrderCartAsStrings()
        {
            Log.Logger.Information("Converting the order cart to strings to be displayed in the console..");
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
            Log.Logger.Information("Processing the order cart into order line items for the repository..");
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
            Log.Logger.Information("Removing ordered product from inventory by changing or removing inventory line items..");
            int newQuantity = lineItem.GetNewQuantityOfAffectedInventoryLineItem();
            
            if (newQuantity < 1)
            {
                OrderService.RemoveLineItemFromLocationInventory(SelectedLocationStock.Find(ili => ili.ProductId == lineItem.affectedInventoryLineItem.ProductId));
                SelectedLocationStock.Remove(SelectedLocationStock.Find(ili => ili.ProductId == lineItem.affectedInventoryLineItem.ProductId));
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
            Log.Logger.Information("Starting Order processing and submission..");
            Order newOrder = new Order(CurrentCustomer, SelectedLocation, GetCurrentSubtotalOfCart(), GetTimeOrderIsPlaced());
            List<OrderLineItem> orderLineItems = ProcessOrderCartIntoOrderLineItems(ref OrderCart, newOrder);

            StringBuilder orderItemsListedToCustomer = new StringBuilder("Adding Cart Items to order:");
            foreach (OrderLineItem lineItem in orderLineItems)
            {
                orderItemsListedToCustomer.AppendLine($"    --- {lineItem.ProductQuantity} of {lineItem.Product.Name}");
                newOrder.AddLineItemToOrder(lineItem);
            }
            Console.WriteLine(orderItemsListedToCustomer.ToString());
            Console.WriteLine($"Submitting order now...");

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

        // TODO: Move this to a UI class.
        public List<string> ReturnAvailableProductsAsStrings()
        {
            Log.Logger.Information("Processing available inventory stock as strings to be displayed in the console..");
            if (SelectedLocationStock.Count < 1)
            {
                Log.Error("The stock of the user's selected location was empty when used to display options. Can't successfully display non-existent options.");
            }
            List<string> availableItems = new List<string>(SelectedLocationStock.Count);

            foreach (InventoryLineItem entry in SelectedLocationStock)
            {
                Product product = entry.Product;

                int productQuantity = GetAvailableQuantityOfInventoryLineItem(entry);

                string productType = Enum.GetName(typeof(ProductType), product.TypeOfProduct);

                availableItems.Add($"{product.Name}: {product.Description} Part of our {productType} collection. Quantity: {productQuantity}");
            }

            return availableItems;
        }

        public int GetAvailableQuantityOfInventoryLineItem(InventoryLineItem selectedLineItem)
        {
            Log.Logger.Information("Computing amount of product stock at a location that isn't already ordered by the current customer..");
            int productQuantity;
            if (OrderCart.Exists(sli => sli.affectedInventoryLineItem == selectedLineItem))
            {
                productQuantity = OrderCart.FindLast(sli => sli.affectedInventoryLineItem == selectedLineItem).GetNewQuantityOfAffectedInventoryLineItem();
            }
            else productQuantity = selectedLineItem.ProductQuantity;
            return productQuantity;
        }
        
    }
}
