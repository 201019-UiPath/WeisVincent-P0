using SufferShopDB.Models;
using SufferShopDB.Repos.DBRepos;
using System;
using System.Collections.Generic;

namespace SufferShopUI.Menus.CustomerMenus
{
    internal class CustomerOrderHistoryMenu : Menu, IMenu
    {
        private readonly DBRepo Repo;

        private readonly Customer CurrentCustomer;
        private readonly List<Order> customerOrders;
        public CustomerOrderHistoryMenu(Customer customer, DBRepo repo)
        {

            CurrentCustomer = customer;
            Repo = repo;
        }

        public override void SetStartingMessage()
        {
            StartMessage = "You've chosen to view your rich history of suffering. \n How would you like the results sorted?";
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
