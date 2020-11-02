using SufferShopBL;
using SufferShopDB.Repos;
using System;
using System.Collections.Generic;
using Xunit.Sdk;

namespace SufferShopUI.Menus.CustomerMenus
{
    internal class CustomerOrderEditorSubMenu : Menu, IMenu
    {

        private OrderBuilder OrderBuilder;
        public CustomerOrderEditorSubMenu(ref OrderBuilder orderBuilder, ref IRepository repo) : base(ref repo)
        {
            this.OrderBuilder = orderBuilder;
        }

        public override void SetStartingMessage()
        {
            StartMessage = "Select one of the staged line items to remove.";
        }

        public override void SetUserChoices()
        {
            PossibleOptions = new List<string>(OrderBuilder.OrderCart.Count);
            // Add the line items of the current order as options to edit.
            PossibleOptions.AddRange(OrderBuilder.GetOrderCartAsStrings());
            PossibleOptions.Add("Use this option to submit your order.");
        }

        public override void ExecuteUserChoice()
        {
            if (PossibleOptions.Count < 1)
            {
                // Handle the possibility that the user has no line items to change, despite this being checked in the Order Menu.
                throw new NotNullException();
            }
            else
            {
                for (int i = 1; i < PossibleOptions.Count; i++)
                {
                    if (selectedChoice == PossibleOptions.Count)
                    {
                        OrderBuilder.BuildAndSubmitOrder();
                        Console.WriteLine("Your order should be sent off now! We don't need any more of your business, we hate money, bye!");
                        Environment.Exit(0);// TODO: How does the program end for a Customer?
                        break;
                    }

                    if (selectedChoice == i)
                    {
                        // Destage the Line Item the user selected and return to the previous menu.
                        OrderBuilder.DestageLineItem(i - 1);
                        return;
                    }

                }
            }
        }


        public OrderBuilder RunAndReturn()
        {
            Run();
            return OrderBuilder;
        }


    }
}
