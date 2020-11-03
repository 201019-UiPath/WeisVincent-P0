﻿using SufferShopBL;
using SufferShopDB.Models;
using SufferShopDB.Repos;
using System;
using System.Collections.Generic;

namespace SufferShopUI.Menus.ManagerMenus
{
    internal class ManagerInventoryLineItemQuantitySubMenu : Menu, IMenu
    {
        private readonly InventoryLineItem selectedLineItem;
        private readonly LocationService LocationService;

        public ManagerInventoryLineItemQuantitySubMenu(ref InventoryLineItem selectedLineItem, ref LocationService locationService, ref IRepository repo) : base(ref repo)
        {
            LocationService = locationService;
            this.selectedLineItem = selectedLineItem;
        }

        public override void SetStartingMessage()
        {
            StartMessage = $"You've chosen to change the quantity of {selectedLineItem.Product.Name} at {selectedLineItem.Location.Name}. \n Would you like to increase it or decrease it?";
        }

        public override void SetUserChoices()
        {
            PossibleOptions = new List<string>()
            {
                "Increase",
                "Decrease",
                "Go back"
            };
        }

        public override void ExecuteUserChoice()
        {
            int selectedQuantityDelta = selectedLineItem.ProductQuantity;
            switch (selectedChoice)
            {
                case 1:
                    Console.WriteLine($"How much {selectedLineItem.Product.Name} would you like to add to stock?");
                    selectedQuantityDelta = MenuUtility.QueryQuantity();
                    selectedLineItem.ProductQuantity += selectedQuantityDelta;
                    break;
                case 2:
                    Console.WriteLine($"How much {selectedLineItem.Product.Name} would you like to remove from stock?");
                    selectedQuantityDelta = MenuUtility.QueryQuantity();
                    while (selectedQuantityDelta > selectedLineItem.ProductQuantity)
                    {
                        Console.WriteLine("You probably shouldn't remove more stock than we have. Might create a black hole. \n Try again.");
                        selectedQuantityDelta = MenuUtility.QueryQuantity();
                    }
                    selectedLineItem.ProductQuantity -= selectedQuantityDelta;
                    if (selectedLineItem.ProductQuantity <= 0)
                    {
                        LocationService.RemoveInventoryLineItemInRepo(selectedLineItem);
                    }

                    break;
                case 3:
                    // No need to queue another menu because the preceding menu will run again.
                    Console.WriteLine("Going back...");
                    return;
            }


        }






    }
}