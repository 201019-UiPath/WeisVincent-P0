using SufferShopBL;
using SufferShopDB;
using SufferShopDB.Models;
using SufferShopDB.Repos.DBRepos;
using SufferShopUI.Menus.ManagerMenus;
using System;
using System.Collections.Generic;

namespace SufferShopUI.Menus
{
    public class SignUpMenu : Menu, IMenu
    {
        private readonly DBRepo Repo;
        private readonly LoginMenu loginMenu;

        internal StartService startService = new StartService();

        public SignUpMenu(DBRepo repo)
        {
            Repo = new DBRepo(new SufferShopContext());
            loginMenu = new LoginMenu(Repo);
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
                    Customer newCustomer = new Customer() { 
                        Name = newName,
                        Email = newEmail,
                        Password = newPassword,
                        Address = newAddress
                    };
                    CustomerService customerService = new CustomerService(Repo);
                    customerService.AddCustomer(newCustomer);
                    break;
                case 2:
                    //TODO: Update a database with an added manager using BL.
                    
                    Manager newManager = new Manager()
                    {
                        Name = newName,
                        Email = newEmail,
                        Password = newPassword,
                    };
                    ManagerSignUpMenu managerSignUpMenu = new ManagerSignUpMenu(Repo, newManager);

                    Manager updatedManager = managerSignUpMenu.RunAndReturnManagerWithSelectedLocation();

                    ManagerService managerService = new ManagerService(Repo);

                    managerService.AddManager(updatedManager);

                    break;
                default:
                    throw new NotImplementedException();
                    break;
            }
            
            
            loginMenu.Run();

        }


    }
}
