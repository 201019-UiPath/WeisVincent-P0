using Serilog;
using SufferShopBL;
using SufferShopDB.Models;
using SufferShopDB.Repos;
using SufferShopLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SufferShopUI.Menus.CustomerMenus
{
    internal class CustomerOrderHistoryMenu : Menu, IMenu
    {
        private readonly Customer CurrentCustomer;
        private readonly CustomerService CustomerService;
        private List<Order> CustomerOrders;
        ProductService ProductService;
        OrderService OrderService;

        public CustomerOrderHistoryMenu(Customer customer, ref IRepository repo) : base(ref repo)
        {
            CurrentCustomer = customer;
            CustomerService = new CustomerService(ref Repo);
            ProductService = new ProductService(ref Repo);
            OrderService = new OrderService(ref Repo);

        }

        public override void SetStartingMessage()
        {
            StartMessage = "You've chosen to view your rich history of suffering. \nHow would you like the results sorted?";
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
            CustomerOrders = CustomerService.GetAllOrdersForCustomer(CurrentCustomer);
            
            List<Order> sortedOrderList = new List<Order>(CustomerOrders.Count);

            sortedOrderList = CustomerOrders;
            
            bool IsSortOrderForward = false;

            IMenu previousMenu = new CustomerStartMenu(CurrentCustomer,ref Repo);

            switch (selectedChoice)
            {
                case 1:
                    sortedOrderList = CustomerOrders.OrderBy(o => o.Subtotal).ToList();
                    MenuUtility.ProcessSortingByDate(ref sortedOrderList, ref IsSortOrderForward);
                    break;
                case 2:
                    sortedOrderList = CustomerOrders.OrderBy(o => o.TimeOrderWasPlaced).ToList();
                    MenuUtility.ProcessSortingByPrice(ref sortedOrderList, ref IsSortOrderForward);
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
                if (OrderService == null)
                {
                    Console.WriteLine("okay then, thanks bungie");
                    Environment.Exit(0);
                }

                MenuUtility.Instance.ShowOrderHistory(ref sortedOrderList,ref OrderService, IsSortOrderForward);
                Console.WriteLine("Really interesting list, right?");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("No orders were found for this account. Cry about it, I suppose.");
                Log.Information($"{e.Message}");
            }

            MenuUtility.Instance.ReadyNextMenu(previousMenu);

        }

        

    }
}


