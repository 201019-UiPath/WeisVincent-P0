using Serilog;
using SufferShopDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SufferShopBL
{
    public class OrderBuilder
    {
        public struct StagedLineItem
        {
            public Product Product;
            public int Quantity;
            public StagedLineItem(Product product, int quantity)
            {
                this.Product = product;
                this.Quantity = quantity;
            }
            
        }

        private Customer CurrentCustomer;

        private readonly LocationService LocationService;
        private readonly Location SelectedLocation;
        public List<InventoryLineItem> SelectedLocationStock;

        public List<StagedLineItem> OrderCart;

        

        public OrderBuilder(Customer customer, LocationService locationService, Location selectedLocation)
        {
            CurrentCustomer = customer;

            LocationService = locationService;
            SelectedLocation = selectedLocation;
            SelectedLocationStock = LocationService.GetAllProductsAtLocationAsync(SelectedLocation).Result;
            OrderCart = new List<StagedLineItem>();
            
        }


        public void StageProductForOrder(InventoryLineItem selection, int quantityOrdered)
        {
            if (MarkProductForRemovalFromStock(selection))
            {
                AddLineItem(selection, quantityOrdered);
            }
            else
            {
                Log.Error("StageProductForOrder() in OrderBuilder failed to remove user selected product from the staging stock.");
            }
        }

        public void StageProductForOrder(InventoryLineItem selection)
        {
            StageProductForOrder(selection, 1);
        }


        private void AddLineItem(InventoryLineItem selection, int quantityOrdered)
        {

            StagedLineItem newLineItem = new StagedLineItem(selection.Product, quantityOrdered);
            OrderCart.Add(newLineItem);
        }

        private bool MarkProductForRemovalFromStock(InventoryLineItem selection)
        {
            return SelectedLocationStock.Remove(selection);
        }


        public void ShowOrderCart()
        {
            if (OrderCart.Count < 1)
            {
                return;
            }
            Console.WriteLine("So far you've ordered:");
            foreach (StagedLineItem entry in OrderCart)
            {
                Console.WriteLine($"{entry.Quantity} of {entry.Product.Name}");
            }
        }

    }
}
