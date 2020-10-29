using SufferShopBL;
using System;

namespace SufferShopUI.Menus
{
    internal static class MenuUtility
    {
        public static string QueryEmail()
        {

            #region Ask User for email and get User object

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

    }
}
