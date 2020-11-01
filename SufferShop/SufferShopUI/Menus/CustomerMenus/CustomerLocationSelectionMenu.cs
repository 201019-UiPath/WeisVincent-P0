using Serilog;
using SufferShopBL;
using SufferShopDB.Models;
using SufferShopDB.Repos;
using System;
using System.Collections.Generic;

namespace SufferShopUI.Menus.CustomerMenus
{
    internal class CustomerLocationSelectionMenu : Menu, IMenu
    {
        private Customer CurrentCustomer;


        LocationService LocationService;
        private List<Location> AllLocations;
        public CustomerLocationSelectionMenu(Customer currentCustomer, IRepository repo) : base(ref repo)
        {
            CurrentCustomer = currentCustomer;

            LocationService = new LocationService(Repo);
            AllLocations = LocationService.GetAllLocations();
        }

        public override void SetStartingMessage()
        {
            StartMessage = "Ready to buy some suffering? Pick a location to get your pain from.";
        }

        public override void SetUserChoices()
        {
            PossibleOptions = new List<string>(AllLocations.Count);
            foreach (Location location in AllLocations)
            {
                PossibleOptions.Add($"{location.Name}, located at: {location.Address}");
            }
            PossibleOptions.Add("Use this option to go back.");
        }

        public override void ExecuteUserChoice()
        {
            IMenu nextMenu = null;
            Location selectedLocation;

            for (int i = 1; i < PossibleOptions.Count; i++)
            {
                if (selectedChoice == PossibleOptions.Count)
                {
                    Console.WriteLine("Going back, ZOOM");
                    nextMenu = new CustomerStartMenu(CurrentCustomer, Repo);
                    break;
                }

                if (selectedChoice == i)
                {
                    try
                    {
                        selectedLocation = AllLocations[i - 1];
                        nextMenu = new CustomerLocationOrderMenu(CurrentCustomer, selectedLocation, Repo, LocationService);
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Log.Error(e.Message);
                    }
                }
            }

            MenuUtility.Instance.ReadyNextMenu(nextMenu);

        }


    }
}