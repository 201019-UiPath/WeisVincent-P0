using Serilog;
using SufferShopDB.Models;
using SufferShopDB.Repos;
using System;
using System.Collections.Generic;

namespace SufferShopUI.Menus.CustomerMenus
{
    internal class CustomerLineItemQuantitySubMenu : Menu, IMenu
    {

        private Product selectedProduct;

        /// <summary>
        /// This number cannot be less than two, and should be as great as the number of the selected product in the user's chosen location.
        /// </summary>
        private int maxQuantity;

        private int selectedQuantity;
        public CustomerLineItemQuantitySubMenu(InventoryLineItem selectedLineItem, IRepository repo) : base(ref repo)
        {
            selectedProduct = selectedLineItem.Product;
            maxQuantity = selectedLineItem.ProductQuantity;
        }


        public override void SetStartingMessage()
        {
            StartMessage = $"You have selected {selectedProduct.Name}, for some great {Enum.GetName(typeof(ProductType), selectedProduct.TypeOfProduct)} suffering. How much would you like?";
        }

        public override void SetUserChoices()
        {
            PossibleOptions = new List<string>(maxQuantity);

            for (int i = 1; i <= maxQuantity; i++)
            {
                if (i == 1)
                {
                    PossibleOptions.Add($"{i} unit of {selectedProduct.Name}.");
                }
                else
                {
                    PossibleOptions.Add($"{i} units of {selectedProduct.Name}.");
                }

            }
            //TODO: Add a way to back out of the product order quantity menu.
        }

        public override void ExecuteUserChoice()
        {
            for (int i = 1; i < PossibleOptions.Count; i++)
            {
                if (selectedChoice == i)
                {
                    try
                    {
                        selectedQuantity = i;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Console.WriteLine("You selected a quantity you shouldn't be able to select. I am breaking apart now.");
                        Log.Error(e.Message);
                        Environment.Exit(0);
                    }
                }
            }
        }


        public int RunAndReturn()
        {
            Run();
            return selectedQuantity;
        }

    }
}