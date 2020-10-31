using Serilog;
using SufferShopBL;
using SufferShopDB.Models;
using SufferShopDB.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SufferShopUI.Menus.CustomerMenus
{
    internal class CustomerOrderHistoryMenu : Menu, IMenu
    {
        private readonly IRepository Repo;

        private readonly Customer CurrentCustomer;
        private readonly CustomerService customerService;
        private List<Order> CustomerOrders;

        public CustomerOrderHistoryMenu(Customer customer, IRepository repo)
        {
            CurrentCustomer = customer;
            Repo = repo;
            customerService = new CustomerService(Repo);
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
            CustomerOrders = customerService.GetAllOrdersForCustomer(CurrentCustomer);

            List<Order> sortedList = new List<Order>(CustomerOrders.Count);

            switch (selectedChoice)
            {
                case 1:
                    sortedList = CustomerOrders.OrderBy(o => o.OrderPlacedTime).ToList();
                    break;
                case 2:
                    sortedList = CustomerOrders.OrderBy(o => o.Subtotal).ToList();
                    break;
                case 3:
                    Console.WriteLine("Going back.");
                    IMenu previousMenu = new CustomerMenu(CurrentCustomer, Repo);
                    MenuUtility.ReadyNextMenu(previousMenu);
                    return;
                    break;
                default:
                    sortedList = null;
                    throw new NotImplementedException();
                    break;
            }

            try {
                ShowOrderHistory(sortedList);
            } catch (NullReferenceException e)
            {
                Log.Error(e.Message);
            }

            Console.WriteLine("Really interesting list, right?");

            IMenu mainCustomerMenu = new CustomerMenu(CurrentCustomer, Repo);
            MenuUtility.ReadyNextMenu(mainCustomerMenu);

        }


        private void ShowOrderHistory(List<Order> ordersToBeShown)
        {
            ProductService productService = new ProductService(Repo);
            foreach (Order order in ordersToBeShown)
            {
                DisplayOrderInformation(order, productService);
            }
        }


        private async void DisplayOrderInformation(Order order, ProductService productService)
        {
            List<OrderLineItem> OrderedProductsInOrder = await productService.GetAllProductsInOrderAsync(order);
            
            StringBuilder orderString = new StringBuilder(
                $"#{order.Id} at {order.LocationPlaced.Name} on {order.OrderPlacedTime.ToShortDateString()}\n_________________\n    Subtotal: ${order.Subtotal}\n    Products in Order: \n"
                );
            foreach (OrderLineItem orderedProduct in OrderedProductsInOrder)
            {
                orderString.Append($"      {orderedProduct.QuantityOfProduct} of {orderedProduct.Product.Name} \n");
            }
            string resultingString = orderString.ToString();
            Console.WriteLine(resultingString);
        }
    }
}
    

