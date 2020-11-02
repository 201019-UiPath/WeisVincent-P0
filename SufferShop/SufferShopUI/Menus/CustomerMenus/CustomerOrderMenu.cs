using Serilog;
using SufferShopBL;
using SufferShopDB.Models;
using SufferShopDB.Repos;
using System;
using System.Collections.Generic;

namespace SufferShopUI.Menus.CustomerMenus
{
    internal class CustomerOrderMenu : Menu, IMenu
    {

        private Customer CurrentCustomer;

        private OrderService OrderService;

        public CustomerOrderMenu(Customer currentCustomer, Location selectedLocation, IRepository repo, LocationService locationService) : base(ref repo)
        {
            CurrentCustomer = currentCustomer;

            OrderService = new OrderService(CurrentCustomer, locationService, selectedLocation, Repo);
        }




        public override void SetStartingMessage()
        {
            StartMessage = "Select a product available at this location to order.";
        }

        public override void SetUserChoices()
        {
            PossibleOptions = new List<string>(OrderService.SelectedLocationStock.Count);
            foreach (InventoryLineItem entry in OrderService.SelectedLocationStock)
            {
                Product product = entry.Product;
                int productQuantity = entry.ProductQuantity;
                string productType = Enum.GetName(typeof(ProductType), product.TypeOfProduct);

                PossibleOptions.Add($"{product.Name}: {product.Description} Part of our {productType} collection.");
            }
            PossibleOptions.Add("Use this option to go back, cancelling your order.");
            if (OrderService.OrderCart.Count! < 1)
            {
                PossibleOptions.Add("Use this option to view and edit your order.");
            };
        }

        public override void ExecuteUserChoice()
        {
            InventoryLineItem selectedLineItem;

            for (int i = 1; i < PossibleOptions.Count; i++)
            {
                if (OrderService.OrderCart.Count! < 1)
                {
                    if (selectedChoice == PossibleOptions.Count)
                    {
                        GoBackToCustomerMenu();
                        break;
                    }
                }
                else
                {
                    if (selectedChoice == PossibleOptions.Count)
                    {
                        EditOrder();
                        break;
                    }

                    if (selectedChoice == PossibleOptions.Count - 1)
                    {
                        GoBackToCustomerMenu();
                        break;
                    }
                }

                if (selectedChoice == i)
                {
                    try
                    {
                        selectedLineItem = OrderService.SelectedLocationStock[i - 1];

                        if (selectedLineItem.ProductQuantity > 1)
                        {
                            int selectedQuantity = new CustomerLineItemQuantitySubMenu(selectedLineItem, Repo).RunAndReturn();
                            OrderService.StageProductForOrder(selectedLineItem, selectedQuantity);
                        }
                        else
                        {
                            OrderService.StageProductForOrder(selectedLineItem);
                        }

                        // Reset this menu with the updated data.
                        RunAgain();
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Log.Error(e.Message);
                    }
                }
            }

        }


        private void EditOrder()
        {
            CustomerOrderEditorMenu OrderEditor = new CustomerOrderEditorMenu(ref OrderService, Repo);
            OrderEditor.Run();
            RunAgain();
        }

        private void RunAgain()
        {
            Console.WriteLine("Want to add more suffering to your cart?");
            Run();
        }

        public void GoBackToCustomerMenu()
        {
            IMenu nextMenu = null;
            Console.WriteLine("Going back, ZOOM");
            nextMenu = new CustomerStartMenu(CurrentCustomer, Repo);
            MenuUtility.Instance.ReadyNextMenu(nextMenu);
        }

    }
}