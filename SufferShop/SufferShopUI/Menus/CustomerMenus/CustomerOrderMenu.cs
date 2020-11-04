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

        private readonly Customer CurrentCustomer;

        private OrderBuilder OrderBuilder;

        private bool CartHasItems;

        public CustomerOrderMenu(ref Customer currentCustomer, ref Location selectedLocation, ref IRepository repo) : base(ref repo)
        {
            CurrentCustomer = currentCustomer;
            CartHasItems = false;

            OrderBuilder = new OrderBuilder(ref CurrentCustomer, ref selectedLocation, ref Repo);
        }




        public override void SetStartingMessage()
        {
            if (OrderBuilder.OrderCart.Count > 0)
            {
                CartHasItems = true;
            };
            StartMessage = "Select a product available at this location to order.";
        }

        public override void SetUserChoices()
        {
            PossibleOptions = new List<string>(OrderBuilder.SelectedLocationStock.Count);

            PossibleOptions.AddRange(OrderBuilder.ReturnAvailableProductsAsStrings());

            if (CartHasItems)
            {
                PossibleOptions.Add("Use this option to view and edit your order.");
            };

            PossibleOptions.Add("Use this option to go back, cancelling your order.");

        }

        public override void ExecuteUserChoice()
        {
            InventoryLineItem selectedLineItem;

            for (int i = 1; i < PossibleOptions.Count; i++)
            {
                if (CartHasItems)
                {
                    if (selectedChoice == PossibleOptions.Count - 1)
                    {
                        EditOrder();
                        break;
                    }
                }
                if (selectedChoice == PossibleOptions.Count)
                {
                    GoBackToCustomerMenu();
                    break;
                }

                if (selectedChoice == i)
                {
                    try
                    {
                        selectedLineItem = OrderBuilder.SelectedLocationStock[i - 1];

                        int productQuantity = OrderBuilder.GetAvailableQuantityOfInventoryLineItem(selectedLineItem);

                        if (productQuantity > 0)
                        {
                            // This submenu will stage the next line item for order itself.
                            new CustomerLineItemQuantitySubMenu(ref selectedLineItem, ref OrderBuilder, ref Repo).Run();
                        }
                        else
                        {
                            Console.WriteLine("Can't order this one, chief. The rest of its stock is in your cart. Silly goose.");
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
            CustomerOrderEditorSubMenu OrderEditor = new CustomerOrderEditorSubMenu(ref OrderBuilder, ref Repo);
            OrderEditor.Run();
            RunAgain();
        }

        private void RunAgain()
        {
            Console.WriteLine("\nWant to add more suffering to your cart?");
            Run();
        }

        public void GoBackToCustomerMenu()
        {
            IMenu nextMenu = new CustomerStartMenu(CurrentCustomer, ref Repo);
            Console.WriteLine("Going back, ZOOM");
            MenuUtility.Instance.ReadyNextMenu(nextMenu);
        }

    }
}