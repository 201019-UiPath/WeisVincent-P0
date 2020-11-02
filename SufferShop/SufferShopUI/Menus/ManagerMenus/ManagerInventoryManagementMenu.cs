using Serilog;
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
            LocationStock = LocationService.GetAllProductsAtLocation(CurrentLocation);

            if (LocationStock.Count < 1)
            {
                throw new NotEmptyException();
            }
            StartMessage = $"Inventory for {CurrentLocation.Name}. Which inventory would you like to replenish/remove?";
        }

        public override void SetUserChoices()
        {
            try
            {
                PossibleOptions = new List<string>(LocationStock.Count);
            } catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Your location's stock is completely empty. A manual database change is required.\nTaking you back to the start menu..");
                Log.Information($"This Manager's location's stock is empty. {e.Message}");
                GoBackToManagerStartMenu();
            }
            // Add the line items of the current location as options to edit.
            PossibleOptions.AddRange(LocationService.GetInventoryStockAsStrings(LocationStock));
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

        public void GoBackToManagerStartMenu()
        {
            IMenu nextMenu;
            Console.WriteLine("Going back, ZOOM");
            nextMenu = new ManagerStartMenu(CurrentManager, Repo);
            MenuUtility.Instance.ReadyNextMenu(nextMenu);
        }


    }
}