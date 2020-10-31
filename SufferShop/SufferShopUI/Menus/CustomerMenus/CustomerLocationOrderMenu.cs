using Serilog;
using SufferShopBL;
using SufferShopDB.Models;
using SufferShopDB.Repos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SufferShopUI.Menus.CustomerMenus
{
    internal class CustomerLocationOrderMenu : Menu, IMenu
    {

        private Customer CurrentCustomer;
        private IRepository Repo;

        private OrderBuilder OrderBuilder;

        public CustomerLocationOrderMenu(Customer currentCustomer, Location selectedLocation, IRepository repo, LocationService locationService)
        {
            CurrentCustomer = currentCustomer;
            Repo = repo;
            

            OrderBuilder = new OrderBuilder(CurrentCustomer, locationService, selectedLocation);
            
        }




        public override void SetStartingMessage()
        {
            OrderBuilder.ShowOrderCart();
            StartMessage = "Select a product available at this location to order.";
        }

        public override void SetUserChoices()
        {
            

            PossibleOptions = new List<string>(OrderBuilder.SelectedLocationStock.Count);
            foreach (InventoryLineItem entry in OrderBuilder.SelectedLocationStock)
            {
                Product product = entry.Product;
                int productQuantity = entry.QuantityOfProduct;
                string productType = Enum.GetName(typeof(ProductType), product.TypeOfProduct);

                PossibleOptions.Add($"{product.Name}: {product.Description} Part of our {productType} collection.");
            }
            PossibleOptions.Add("Use this option to edit your order.");
            PossibleOptions.Add("Use this option to go back, cancelling your order.");
        }

        public override void ExecuteUserChoice()
        {
            IMenu nextMenu = null;
            InventoryLineItem selectedLineItem;

            for (int i = 1; i < PossibleOptions.Count; i++)
            {
                if (selectedChoice == PossibleOptions.Count)
                {
                    // TODO: Add Edit Order function in OrderBuilder

                }


                if (selectedChoice == PossibleOptions.Count - 1)
                {
                    Console.WriteLine("Going back, ZOOM");
                    nextMenu = new CustomerMenu(CurrentCustomer, Repo);
                    break;
                }
                
                if (selectedChoice == i)
                {
                    try
                    {
                        selectedLineItem = OrderBuilder.SelectedLocationStock[i - 1];
                        
                        if (selectedLineItem.QuantityOfProduct > 1)
                        {
                            
                            int selectedQuantity = new CustomerLineItemQuantityMenu(selectedLineItem).RunAndReturn();
                            OrderBuilder.StageProductForOrder(selectedLineItem, selectedQuantity);
                        } else
                        {
                            OrderBuilder.StageProductForOrder(selectedLineItem);
                        }
                        
                        // Reset this menu with the updated data.
                        this.RunAgain();
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Log.Error(e.Message);
                    }
                }
            }

        }


        private void RunAgain()
        {
            Console.WriteLine("Want to add more suffering to your cart?");
            Run();
        }

        

    }
}