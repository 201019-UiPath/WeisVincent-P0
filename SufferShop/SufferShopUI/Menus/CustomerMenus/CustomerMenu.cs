using Serilog;
using SufferShopDB.Models;
using SufferShopDB.Repos;
using SufferShopDB.Repos.DBRepos;
using System;
using System.Collections.Generic;

namespace SufferShopUI.Menus.CustomerMenus
{
    internal class CustomerMenu : Menu, IMenu
    {
        private readonly IRepository Repo;

        private readonly Customer CurrentCustomer;

        private IMenu NextMenu;
        public CustomerMenu(Customer customer, IRepository repo)
        {
            CurrentCustomer = customer;
            Repo = repo;
        }

        public override void SetStartingMessage()
        {
            StartMessage = "Welcome, loyal sufferer! \n You may view your order history, or select a location to begin placing your order!";
        }

        public override void SetUserChoices()
        {
            PossibleOptions = new List<string>() {
            "View Order History.",
            "Select a location to waste money at.",
            "Exit"
        };
        }




        public override void ExecuteUserChoice()
        {
            switch (selectedChoice)
            {
                case 1:
                    NextMenu = new CustomerOrderHistoryMenu(CurrentCustomer, Repo);
                    break;
                case 2:
                    NextMenu = new CustomerLocationSelectionMenu(CurrentCustomer, Repo);
                    break;
                case 3:
                    Console.WriteLine("Enjoy your suffering!");
                    return;
                    //Environment.Exit(Environment.ExitCode);
                    break;
                default:
                    throw new NotImplementedException();
                    break;
            }

            try {
                MenuUtility.ReadyNextMenu(NextMenu);
            } catch (NullReferenceException e)
            {
                Log.Error(e.Message);
            }
            

        }



    }
}
