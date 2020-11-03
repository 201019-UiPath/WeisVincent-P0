﻿using Serilog;
using SufferShopBL;
using SufferShopDB.Models;
using SufferShopDB.Repos;
using System;
using System.Collections.Generic;
using Xunit.Sdk;

namespace SufferShopUI.Menus.ManagerMenus
{
    internal class ManagerInventoryManagementMenu : Menu, IMenu
    {
        private Manager CurrentManager;
        private Location CurrentLocation;
        private LocationService LocationService;
        private List<InventoryLineItem> LocationStock;

        public ManagerInventoryManagementMenu(Manager currentManager, ref IRepository repo) : base(ref repo)
        {
            CurrentManager = currentManager;
            CurrentLocation = CurrentManager.Location;
            LocationService = new LocationService(ref Repo);
            
        }

        public override void SetStartingMessage()
        {
            LocationStock = LocationService.GetAllProductsStockedAtLocation(CurrentLocation);
            StartMessage = $"Inventory for {CurrentLocation.Name}. Which inventory would you like to replenish/remove?";
            if (LocationStock.Count < 1)
            {
                StartMessage = $"Inventory for {CurrentLocation.Name}. It's empty. Want to add something?";
            }
        }

        public override void SetUserChoices()
        {
            try
            {
                PossibleOptions = new List<string>(LocationStock.Count);
                // Add the line items of the current location as options to edit.
                PossibleOptions.AddRange(LocationService.GetInventoryStockAsStrings(LocationStock));
            } catch (ArgumentOutOfRangeException e)
            {
                Log.Information($"This Manager's location's stock is empty. {e.Message}");
            }
            PossibleOptions.Add("Use this option to add a new product not listed here.");
            PossibleOptions.Add("Use this option to go back.");
        }

        public override void ExecuteUserChoice()
        {
            InventoryLineItem selectedLineItem;

            for (int i = 1; i < PossibleOptions.Count; i++)
            {
                if (selectedChoice == PossibleOptions.Count)
                {
                    GoBackToManagerStartMenu();
                    break;
                }

                if (selectedChoice == PossibleOptions.Count - 1)
                {
                    RunProductAdditionSubmenu();
                    // Reset this menu with the updated data.
                    RunAgain();
                    break;
                }


                if (selectedChoice == i)
                {
                    try
                    {
                        selectedLineItem = LocationStock[i - 1];

                        if (selectedLineItem.ProductQuantity > 0)
                        {
                            // TODO: Add menus for manager to add or remove this inventory item
                            new ManagerInventoryLineItemQuantitySubMenu(ref selectedLineItem, ref LocationService,ref Repo).Run();
                            LocationService.UpdateInventoryLineItemInRepo(selectedLineItem);
                        }
                        else
                        {
                            throw new Exception("How the hell is there an Inventory line item with zero quantity? I am upset.");
                        }
                        // Reset this menu with the updated data.
                        RunAgain();
                        break;
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

        private void GoBackToManagerStartMenu()
        {
            IMenu nextMenu;
            Console.WriteLine("Going back, ZOOM");
            nextMenu = new ManagerStartMenu(CurrentManager,ref Repo);
            MenuUtility.Instance.ReadyNextMenu(nextMenu);
        }

        private void RunProductAdditionSubmenu()
        {
            IMenu newSubMenu;
            Console.WriteLine("Going back, ZOOM");
            newSubMenu = new ManagerProductAdditionSubMenu(ref CurrentLocation, ref LocationStock, ref LocationService,ref Repo);
            newSubMenu.Run();
        }


    }
}