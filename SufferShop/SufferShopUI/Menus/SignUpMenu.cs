using SufferShopBL;
using SufferShopDB.Models;
using SufferShopDB.Repos;
using SufferShopUI.Menus.ManagerMenus;
using System;
using System.Collections.Generic;

namespace SufferShopUI.Menus
{
    public class SignUpMenu : Menu, IMenu
    {
        private readonly IMenu loginMenu;

        internal StartService startService;

        public SignUpMenu(IRepository repo) : base(ref repo)
        {
            loginMenu = new LoginMenu(Repo);
            startService = new StartService(ref Repo);
        }

        public override void SetStartingMessage()
        {
            StartMessage = "Are you signing up as a Customer or Manager?";
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
            // TODO: Implement Sign Up functionality
            // 1: Ask for email 
            // 2: check if email matches with any other customer
            // 3: ask for password, then name and address

            string newEmail = MenuUtility.QueryEmail();

            string newPassword = MenuUtility.QueryPassword();
            Console.WriteLine("Enter the same password to prove to my satisfaction that you can type.");
            string confirmationPassword = MenuUtility.QueryPassword();

            while (newPassword != confirmationPassword)
            {
                Console.WriteLine("Your confirmation password did not match. I'm telling mom. \n Try again.");
                newPassword = MenuUtility.QueryPassword();
                confirmationPassword = MenuUtility.QueryPassword();
            }

            string newName = MenuUtility.QueryName();



            // TODO: When SignUp() ends, add the new customer data to DB/file
            switch (selectedChoice)
            {
                case 1:
                    //TODO: Update a database with an added customer using BL.
                    string newAddress = MenuUtility.QueryAddress();

                    Customer newCustomer = new Customer(newName, newEmail, newPassword, newAddress);

                    CustomerService customerService = new CustomerService(Repo);
                    customerService.AddCustomerToRepo(newCustomer);
                    break;
                case 2:
                    Manager newManager = new Manager(newName, newEmail, newPassword);

                    ManagerSignUpMenu managerSignUpMenu = new ManagerSignUpMenu( Repo, ref newManager);

                    Manager updatedManager = managerSignUpMenu.RunAndReturnManagerWithSelectedLocation();

                    ManagerService managerService = new ManagerService(Repo);

                    managerService.AddManager(updatedManager);

                    break;
                default:
                    throw new NotImplementedException();
                    //break;
            }

            MenuUtility.Instance.ReadyNextMenu(loginMenu);

        }


    }
}
