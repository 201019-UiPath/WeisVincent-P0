using Serilog;
using SufferShopBL;
using SufferShopDB.Models;
using SufferShopLib;
using SufferShopLib.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SufferShopUI.Menus
{
    internal sealed class MenuUtility
    {
        private static readonly MenuUtility _instance = new MenuUtility();

        internal Queue<IMenu> MenuChain;

        static MenuUtility() { }
        private MenuUtility() { MenuChain = new Queue<IMenu>(); }

        public static MenuUtility Instance { get { return _instance; } }


        internal void StartMenuChain(IMenu firstMenu)
        {
            Log.Information($"Starting menu chain...");
            ReadyNextMenu(firstMenu);
            RunThroughMenuChain();
        }

        internal void ReadyNextMenu(IMenu nextMenu)
        {
            Log.Information($"Adding new menu to menu chain: {nextMenu.GetType().Name}");
            MenuChain.Enqueue(nextMenu);
        }

        internal void RunThroughMenuChain()
        {
            while (MenuChain.Count > 0)
            {
                MenuChain.Dequeue().Run();
            }
        }

        public static string QueryName()
        {

            #region Ask User for Name

            Console.WriteLine("Enter your name:");
            string inputName = Console.ReadLine().Trim();

            while (!StartService.ValidateNameInput(inputName))
            {
                Console.WriteLine("Your input must be a valid name.");
                Console.WriteLine("Enter your name:");
                inputName = Console.ReadLine().Trim();
            }

            return inputName;

            #endregion
        }

        public static string QueryProductName()
        {

            #region Ask User for Name

            Console.WriteLine("Enter a name for the Product:");
            string inputName = Console.ReadLine().Trim();

            // TODO: Refine conditions for Product names.
            InputValidator validator = new InputValidator(new NotEmptyInputCondition());
            while (!validator.ValidateInput(inputName))
            {
                Console.WriteLine("Your input must be a valid product name.");
                Console.WriteLine("Enter a name for the Product:");
                inputName = Console.ReadLine().Trim();
            }

            return inputName;

            #endregion
        }


        public static string QueryEmail()
        {

            #region Ask User for email

            Console.WriteLine("Enter your email:");
            string inputEmail = Console.ReadLine().Trim();

            while (!StartService.ValidateEmailInput(inputEmail))
            {
                Console.WriteLine("Your input must be in email format.");
                Console.WriteLine("Enter your email:");
                inputEmail = Console.ReadLine().Trim();
            }

            return inputEmail;

            #endregion
        }

        public static string QueryPassword()
        {
            #region Ask User for Password

            Console.WriteLine("Enter your password:");
            string inputPassword = Console.ReadLine().Trim();
            while (!StartService.ValidatePasswordInput(inputPassword))
            {
                Console.WriteLine("Your input must be non-empty, with at least 8 word characters.");
                Console.WriteLine("Enter your password:");
                inputPassword = Console.ReadLine().Trim();
            }

            #endregion

            return inputPassword;

        }

        public static string QueryAddress()
        {

            #region Ask User for address

            Console.WriteLine("Enter your address:");
            string inputAddress = Console.ReadLine().Trim();

            while (!StartService.ValidateAddressInput(inputAddress))
            {
                Console.WriteLine("Your input must be a valid address.");
                Console.WriteLine("Enter your name:");
                inputAddress = Console.ReadLine().Trim();
            }

            return inputAddress;

            #endregion
        }

        #region User query and input methods
        internal static void DisplayPossibleChoicesToUser(string startMessage, List<string> possibleOptions)
        {
            Console.WriteLine(startMessage);
            DisplayPossibleChoicesToUser(possibleOptions);
        }

        internal static void DisplayPossibleChoicesToUser(List<string> possibleOptions)
        {
            Console.WriteLine("Press the corresponding number to choose the option that best suits you.");
            for (int i = 0; i < possibleOptions.Count; i++)
            {
                Console.WriteLine($"[{i + 1}]    {possibleOptions[i]}");
            }
        }

        internal static int ProcessUserInputAgainstPossibleChoices(List<string> possibleOptions)
        {
            IInputCondition condition;
            if (possibleOptions.Count <= 9)
            {
                condition = new IsOneDigitCondition();
            }
            else
            {
                condition = new IsOneOrTwoDigitsCondition();
            }

            InputValidator validator = new InputValidator(condition);

            bool userInputIsInRange = false;
            do
            {
                string userInput = Console.ReadLine().Trim();
                while (!validator.ValidateInput(userInput))
                {
                    Console.WriteLine("That input wasn't it, sufferer. Give it another go, it needs to be a whole number.");
                    userInput = Console.ReadLine().Trim();
                }

                int userChoice = int.Parse(userInput);
                if (userChoice < 1 && userChoice > possibleOptions.Count)
                {
                    Console.WriteLine("That input wasn't it, sufferer. Give it another go, it needs to be one of the offered choices.");
                    continue;
                }
                else
                {
                    userInputIsInRange = true;
                    return userChoice;
                }

            } while (!userInputIsInRange);
            throw new Exception("User input was processed incorrectly, validated a false input.");
        }

        internal static string QueryDescription()
        {
            Console.WriteLine("Enter your description:");
            string inputDescription = Console.ReadLine().Trim();

            InputValidator validator = new InputValidator(new NotEmptyInputCondition());
            const int maxLength = 140;
            while (!validator.ValidateInput(inputDescription) || inputDescription.Length > maxLength)
            {
                Console.WriteLine($"Your input must be a valid description, no more than {maxLength} characters.");
                Console.WriteLine("Enter your description:");
                inputDescription = Console.ReadLine().Trim();
            }

            return inputDescription;
        }

        internal static int QueryQuantity()
        {
            IInputCondition condition;
            condition = new IsOneOrTwoDigitsCondition();

            InputValidator validator = new InputValidator(condition);

            bool userInputIsInRange = false;
            do
            {
                string userInput = Console.ReadLine().Trim();
                while (!validator.ValidateInput(userInput))
                {
                    Console.WriteLine("That input wasn't it, sufferer. Give it another go, it needs to be a whole number.");
                    userInput = Console.ReadLine().Trim();
                }

                int userChoice = int.Parse(userInput);
                if (userChoice < 1 && userChoice > 80)
                {
                    Console.WriteLine("That input wasn't it, sufferer. Give it another go, it needs to be between 0 and 50.");
                    continue;
                }
                else
                {
                    userInputIsInRange = true;
                    return userChoice;
                }
            } while (!userInputIsInRange);
            throw new Exception("User input was processed incorrectly, validated a false input.");
        }

        #endregion


        #region Order History methods
        internal void ShowOrderHistory(ref List<Order> ordersToBeShown, ref OrderService orderService, bool isIteratedForward)
        {
            if (!isIteratedForward)
            {
                ordersToBeShown.Reverse();
            }
            for (int i = 0; i < ordersToBeShown.Count; i++)
            {
                DisplayOrderInformation(ordersToBeShown[i], ref orderService);
                if (ordersToBeShown[i] == null)
                {
                    Console.WriteLine("okay then, thanks order");
                    Environment.Exit(0);
                }
            }
        }


        private void DisplayOrderInformation(Order order, ref OrderService orderService)
        {
            List<OrderLineItem> OrderedProductsInOrder = orderService.GetAllProductsInOrder(order);

            DateTime orderTime = DateTimeUtility.GetDateTimeFromUnixEpochAsDouble(order.TimeOrderWasPlaced);
            if (OrderedProductsInOrder == null)
            {
                Console.WriteLine("okay then, thanks time");
                Environment.Exit(0);
            }

            StringBuilder orderString = new StringBuilder(
                $"#{order.Id} at {order.Location.Name} on {orderTime.ToShortDateString()}\n_________________\n    Subtotal: ${order.Subtotal}\n    Products in Order: \n"
                );
            foreach (OrderLineItem orderedProduct in OrderedProductsInOrder)
            {
                orderString.Append($"      {orderedProduct.ProductQuantity} of {orderedProduct.Product.Name} \n");
            }
            string resultingString = orderString.ToString();

            Console.WriteLine(resultingString);
        }

        private async void DisplayOrderInformationAsync(Order order, OrderService orderService)
        {
            List<OrderLineItem> OrderedProductsInOrder = await orderService.GetAllProductsInOrderAsync(order);

            DateTime orderTime = DateTimeUtility.GetDateTimeFromUnixEpochAsDouble(order.TimeOrderWasPlaced);

            StringBuilder orderString = new StringBuilder(
                $"#{order.Id} at {order.Location.Name} on {orderTime.ToShortDateString()}\n_________________\n    Subtotal: ${order.Subtotal}\n    Products in Order: \n"
                );
            foreach (OrderLineItem orderedProduct in OrderedProductsInOrder)
            {
                orderString.Append($"      {orderedProduct.ProductQuantity} of {orderedProduct.Product.Name} \n");
            }
            string resultingString = orderString.ToString();
            Console.WriteLine(resultingString);
        }

        public static void ProcessSortingByDate(ref bool sortOrder)
        {

            string sortStartMessage = "Would you like the results sorted oldest to latest or latest to oldest?";
            List<string> sortOptions = new List<string>(2)
                    {
                        "Oldest to Latest.", "Latest to Oldest."
                    };
            DisplayPossibleChoicesToUser(sortStartMessage, sortOptions);
            sortOrder = (ProcessUserInputAgainstPossibleChoices(sortOptions)) switch
            {
                1 => true,
                2 => false,
                _ => throw new NotImplementedException(),
            };
        }

        public static void ProcessSortingByPrice(ref bool sortOrder)
        {

            string sortStartMessage = "You've chosen to sort orders by subtotal. Sort from lowest to highest subtotal, or highest to lowest subtotal?";
            List<string> sortOptions = new List<string>(2)
                    {
                        "Lowest to highest.", "Highest to Lowest."
                    };
            DisplayPossibleChoicesToUser(sortStartMessage, sortOptions);
            sortOrder = (ProcessUserInputAgainstPossibleChoices(sortOptions)) switch
            {
                1 => true,
                2 => false,
                _ => throw new NotImplementedException(),
            };
        }


        #endregion

    }
}
