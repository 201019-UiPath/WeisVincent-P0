using SufferShopBL;
using SufferShopDB.Models;
using SufferShopLib.Validation;
using System;
using System.Collections.Generic;

namespace SufferShopUI.Menus
{
    public delegate void MenuSequence(string[] possibleOptions);

    /// <summary>
    /// This is a sample menu to practice interfaces, menu creation, and XML documentation. This utilized the VSCode C# XML Documentation Extension:
    /// VS Marketplace Link: https://marketplace.visualstudio.com/items?itemName=k--kato.docomment
    /// </summary> 
    public sealed class StartMenu : Menu, IMenu
    {

        internal LoginService StartService = new LoginService();

        #region Set up menu options
        public override void SetStartingMessage()
        {
            StartMessage = "Welcome! Please select which operation you'd like to perform!";
        }

        public override void SetUserChoices()
        {
            PossibleOptions = new List<string>() {
                "Sign-up for a new account.",
                "Log-in to an existing account."
            };
        }
        #endregion

        public override void ExecuteUserChoice()
        {
            switch (selectedChoice)
            {
                case 1:
                    IMenu signUpMenu = new SignUpMenu();
                    signUpMenu.Run();
                    break;
                case 2:
                    Login();
                    break;
                default:
                    throw new NotImplementedException();
                    break;
            }
        }




        private string QueryEmail()
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

        private string QueryPassword()
        {
            #region Ask User for Password
            
            Console.WriteLine("Enter your password:");
            string inputPassword = Console.ReadLine().Trim();
            while (!StartService.ValidatePasswordInput(inputPassword))
            {
                Console.WriteLine("Your input must be non-empty.");
                Console.WriteLine("Enter your password:");
                inputPassword = Console.ReadLine().Trim();
            }
            
            #endregion

            return inputPassword;

        }

        public void Login()
        {
            User userLoggingIn;
            
                        // TODO: Implement Login functionality for existing users

            Console.WriteLine("Please put in your email, then your password to login.");


            userLoggingIn = StartService.GetUserByEmail(QueryEmail());

            if (userLoggingIn is null)
            {
                FailedLoginMenu failedLoginMenu = new FailedLoginMenu();
                failedLoginMenu.Run();
            }
            else if (userLoggingIn is Customer || userLoggingIn is Manager)
            {
                string userInputPassword = QueryPassword();
                while (userInputPassword != userLoggingIn.Password)
                {
                    userInputPassword = QueryPassword();
                }
            }



            //TODO: Check at Login() if the inputted email and password match any existing customer or Manager, then make the current user either customer or manager.





            // TODO: Move to next menu.



        }


    }
}