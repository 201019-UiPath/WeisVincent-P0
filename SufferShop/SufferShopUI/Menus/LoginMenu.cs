using SufferShopBL;
using SufferShopDB.Models;
using SufferShopDB.Repos.DBRepos;
using SufferShopUI.Menus.CustomerMenus;
using System;
using System.Collections.Generic;

namespace SufferShopUI.Menus
{
    public sealed class LoginMenu : Menu, IMenu
    {
        private readonly DBRepo Repo;

        internal StartService startService = new StartService();

        public LoginMenu(DBRepo repo)
        {
            Repo = repo;
        }

        public override void SetStartingMessage()
        {
            StartMessage = "Are you logging in as a Customer or Manager?";
        }

        public override void SetUserChoices()
        {
            PossibleOptions = new List<string>() {
            "Customer",
            "Manager"
        };
        }




        public override void ExecuteUserChoice()
        {
            switch (selectedChoice)
            {
                case 1:
                    LoginAsCustomer();
                    break;
                case 2:
                    LoginAsManager();
                    break;
                default:
                    throw new NotImplementedException();
                    break;
            }


        }






        public void LoginAsCustomer()
        {
            CustomerService customerService = new CustomerService(Repo);
            Customer userLoggingIn;


            Console.WriteLine("Please put in your email, then your password to login.");

            userLoggingIn = customerService.GetCustomerByEmail(MenuUtility.QueryEmail());


            if (userLoggingIn is null)
            {
                FailedLoginMenu failedLoginMenu = new FailedLoginMenu();
                failedLoginMenu.Run();
            }
            else if (userLoggingIn is Customer)
            {
                string userInputPassword;
                userInputPassword = MenuUtility.QueryPassword();
                while (userInputPassword != userLoggingIn.Password)
                {
                    userInputPassword = MenuUtility.QueryPassword();
                }
            }

            Program.CurrentUser = userLoggingIn;


            // TODO: Move to Customer menu.
            CustomerMenu customerMenu = new CustomerMenu(userLoggingIn, Repo);

        }

        public void LoginAsManager()
        {
            ManagerService managerService = new ManagerService(Repo);

            Manager managerLoggingIn;

            Console.WriteLine("Please put in your email, then your password to login.");


            managerLoggingIn = managerService.GetManagerByEmail(MenuUtility.QueryEmail());

            string userInputPassword;

            if (managerLoggingIn is null)
            {
                FailedLoginMenu failedLoginMenu = new FailedLoginMenu();
                failedLoginMenu.Run();
            }
            else if (managerLoggingIn is Manager)
            {
                userInputPassword = MenuUtility.QueryPassword();
                while (userInputPassword != managerLoggingIn.Password)
                {
                    userInputPassword = MenuUtility.QueryPassword();
                }
            }

            Program.CurrentUser = managerLoggingIn;


            // TODO: Move to Manager menu.
            ManagerMenu ManagerMenu = new ManagerMenu(managerLoggingIn, Repo);

        }




        public void Login()
        {
            User userLoggingIn;

            // TODO: Implement Login functionality for existing users

            Console.WriteLine("Please put in your email, then your password to login.");


            userLoggingIn = startService.GetUserByEmail(MenuUtility.QueryEmail());

            if (userLoggingIn is null)
            {
                FailedLoginMenu failedLoginMenu = new FailedLoginMenu();
                failedLoginMenu.Run();
            }
            else if (userLoggingIn is Customer || userLoggingIn is Manager)
            {
                string userInputPassword = MenuUtility.QueryPassword();
                while (userInputPassword != userLoggingIn.Password)
                {
                    userInputPassword = MenuUtility.QueryPassword();
                }
            }



            // TODO: When SignUp() ends, add the new customer data to DB/file
            switch (selectedChoice)
            {
                case 1:
                    //TODO: Update a database with an added customer using BL.

                    break;
                case 2:
                    //TODO: Update a database with an added manager using BL.

                    break;
                default:
                    throw new NotImplementedException();
                    break;
            }

            //TODO: Check at Login() if the inputted email and password match any existing customer or Manager, then make the current user either customer or manager.





            // TODO: Move to next menu.


        }

    }
}
