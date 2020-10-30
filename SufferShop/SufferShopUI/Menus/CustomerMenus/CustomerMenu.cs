using Serilog;
using SufferShopDB.Models;
using SufferShopDB.Repos.DBRepos;
using System;
using System.Collections.Generic;

namespace SufferShopUI.Menus.CustomerMenus
{
    internal class CustomerMenu : Menu, IMenu
    {
        private readonly DBRepo Repo;

        private readonly Customer CurrentCustomer;

        private IMenu NextMenu;
        public CustomerMenu(Customer customer, DBRepo repo)
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
            "Select a location to waste money at."
        };
        }




        public override void ExecuteUserChoice()
        {
            switch (selectedChoice)
            {
                case 1:
                    // TODO: Implement the ability to view customer order history with another menu.
                    NextMenu = new CustomerOrderHistoryMenu(CurrentCustomer, Repo);
                    break;
                case 2:
                    // TODO: Implement menu where the user can see the locations available to them to order from.
                    //NextMenu = new 
                    break;
                default:
                    throw new NotImplementedException();
                    break;
            }

            try { 
                NextMenu.Run(); 
            } catch (NullReferenceException e)
            {
                Log.Error(e.Message);
            }
            

        }



    }
}
