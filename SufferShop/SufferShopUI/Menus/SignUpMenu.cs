using SufferShopBL;
using SufferShopDB;
using SufferShopDB.Repos.DBRepos;
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


            Console.WriteLine("Enter your name:");
            string newName = Console.ReadLine().Trim();

            Console.WriteLine("Enter your email:");
            string newEmail = Console.ReadLine().Trim();


            /*
            System.Console.WriteLine("Enter a password:");
            string pwdFirstEntry = System.Console.ReadLine();
            System.Console.WriteLine("Reenter the same password:");
            string pwdSecondEntry = System.Console.ReadLine();
            if (pwdFirstEntry == pwdSecondEntry) {
                newCustomer.password = pwdSecondEntry;
            } else {

            }*/

            Console.WriteLine("Enter a password:");
            string newPassword = Console.ReadLine();




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




        }


    }
}
