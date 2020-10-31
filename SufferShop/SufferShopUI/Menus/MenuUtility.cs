using SufferShopBL;
using System;

namespace SufferShopUI.Menus
{
    internal static class MenuUtility
    {



        internal static void ReadyNextMenu(IMenu nextMenu)
        {
            Program.MenuChain.Enqueue(nextMenu);
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

            Console.WriteLine("Enter your name:");
            string inputAddress = Console.ReadLine().Trim();

            while (!StartService.ValidateAddressInput(inputAddress))
            {
                Console.WriteLine("Your input must be a valid name.");
                Console.WriteLine("Enter your name:");
                inputAddress = Console.ReadLine().Trim();
            }

            return inputAddress;

            #endregion
        }

    }
}
