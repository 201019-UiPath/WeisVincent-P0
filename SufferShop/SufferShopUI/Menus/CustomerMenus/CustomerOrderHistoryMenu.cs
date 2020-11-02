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

        public CustomerOrderHistoryMenu(Customer customer, IRepository repo) : base(ref repo)
        {
            CurrentCustomer = customer;
            CustomerService = new CustomerService(Repo);
            ProductService = new ProductService(Repo);
        }

        public override void SetStartingMessage()
        {
            StartMessage = "You've chosen to view your rich history of suffering. \n How would you like the results sorted?";
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
            CustomerOrders = CustomerService.GetAllOrdersForCustomerAsync(CurrentCustomer);

            List<Order> sortedOrderList = new List<Order>(CustomerOrders.Count);
            bool IsSortOrderForward = false;

            IMenu previousMenu = new CustomerStartMenu(CurrentCustomer, Repo);

            switch (selectedChoice)
            {
                case 1:
                    sortedOrderList = CustomerOrders.OrderBy(o => o.Subtotal).ToList();
                    MenuUtility.ProcessSortingByDate(sortedOrderList, ref IsSortOrderForward);

                    break;
                case 2:
                    sortedOrderList = CustomerOrders.OrderBy(o => o.TimeOrderWasPlaced).ToList();
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


