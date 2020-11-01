using Serilog;
using SufferShopBL;
using SufferShopDB.Models;
using SufferShopDB.Repos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SufferShopUI.Menus.ManagerMenus
{
    internal class ManagerLocationOrderHistoryMenu : Menu, IMenu
    {
        private Manager currentManager;
        private readonly ManagerService managerService;
        private List<Order> LocationOrders;

        private readonly LocationService LocationService;
        private readonly ProductService ProductService;

        public ManagerLocationOrderHistoryMenu(Manager currentManager, ref IRepository repo) : base(ref repo)
        {
            this.currentManager = currentManager;
            managerService = new ManagerService(Repo);
            LocationService = new LocationService(Repo);
            ProductService = new ProductService(Repo);
        }

        public override void SetStartingMessage()
        {
            StartMessage = "You've chosen to view this location's rich history of suffering. \n How would you like the results sorted?";
        }

        public override void SetUserChoices()
        {
            PossibleOptions = new List<string>() {
                "Sort by date the order was placed.",
                "Sort by price.",
                "Go back."
            };
        }

        public override void ExecuteUserChoice()
        {
            LocationOrders = LocationService.GetAllOrdersForLocation(currentManager.Location);

            List<Order> sortedOrderList = new List<Order>(LocationOrders.Count);
            bool IsSortOrderForward = false;

            IMenu previousMenu = new ManagerStartMenu(currentManager, Repo);

            switch (selectedChoice)
            {
                case 1:
                    sortedOrderList = LocationOrders.OrderBy(o => o.Subtotal).ToList();
                    MenuUtility.ProcessSortingByDate(sortedOrderList, ref IsSortOrderForward);

                    break;
                case 2:
                    sortedOrderList = LocationOrders.OrderBy(o => o.TimeOrderWasPlaced).ToList();
                    MenuUtility.ProcessSortingByPrice(sortedOrderList, ref IsSortOrderForward);
                    break;
                case 3:
                    Console.WriteLine("Going back.");
                    
                    MenuUtility.Instance.ReadyNextMenu(previousMenu);
                    return;
                //break;
                default:
                    sortedOrderList = null;
                    throw new NotImplementedException();
                    //break;
            }

            try
            {
                MenuUtility.Instance.ShowOrderHistory(sortedOrderList, ProductService, IsSortOrderForward);
            }
            catch (NullReferenceException e)
            {
                Log.Error(e.Message);
            }

            Console.WriteLine("Really interesting list, right?");

            
            MenuUtility.Instance.ReadyNextMenu(previousMenu);
        }

        
    }
}