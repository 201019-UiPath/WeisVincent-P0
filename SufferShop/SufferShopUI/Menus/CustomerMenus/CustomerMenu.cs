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

                    break;
                case 2:

                    break;
                default:
                    throw new NotImplementedException();
                    break;
            }

        }



    }
}
