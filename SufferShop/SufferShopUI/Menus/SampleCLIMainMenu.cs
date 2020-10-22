using System;
using SufferShopLib;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices.ComTypes;

namespace SufferShopUI.Menus
{
    /// <summary>
    /// This is a sample menu to practice interfaces, menu creation, and XML documentation. This utilized the VSCode C# XML Documentation Extension:
    /// Name: C# XML Documentation Comments
    /// Id: k--kato.docomment
    /// Description: Generate C# XML documentation comments for ///
    /// Version: 0.1.18
    /// Publisher: Keisuke Kato
    /// VS Marketplace Link: https://marketplace.visualstudio.com/items?itemName=k--kato.docomment
    /// </summary> 
    public static class SampleCLIMainMenu//:IMenu
    {

        enum UserStartOption
        {
            None, SignUp, LoginAsCustomer,LoginAsManager
        }
        
        /// <summary>
        /// Starting point of menus, where the user selects what they want to do. :)
        /// </summary>
        public static int Start()
        {
            

            System.Console.WriteLine("Welcome Friend! What would you like to do today?");
            // Options
            int numberOfStartOptions = Enum.GetValues(typeof(UserStartOption)).Length;
            SortedDictionary<int,string> userOptions = new SortedDictionary<int, string>();

            //userOptions.Add( (int)UserStartOption.None, "Create a customer account.");
            userOptions.Add( (int)UserStartOption.SignUp, "Create a customer account.");
            userOptions.Add( (int)UserStartOption.LoginAsCustomer, "Login to an existing customer account.");
            userOptions.Add( (int)UserStartOption.LoginAsManager, "Login to an existing manager account.");

            foreach (KeyValuePair<int,string> option in userOptions)
            {
                Console.WriteLine($"{option.Key}] {option.Value}");
            }
            
            
            string userInputStart = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine("");
            if (Regex.IsMatch(userInputStart, @"\\d"))
            {

            }

            return 0; // TODO: Remove this placeholder return value in SampleMainMenu.Start()
            // TODO: Validate input at the start for a number representing an option and return that number from this Start() method.


        }
        /// <summary>
        /// This method gets the necessary customer information from a new user of the program.
        /// </summary>
        public static CustomerSample GetCustomerDetails()
        {
            CustomerSample newCustomer = new CustomerSample();

            do
            {
                System.Console.WriteLine("Enter your name:");
                newCustomer.Name = System.Console.ReadLine();
            } while (!Regex.IsMatch(newCustomer.Name, "[\\d]"));// If there is a digit/number in the name, keep asking for a name.

            do
            {
                System.Console.WriteLine("Enter your email:");
                newCustomer.Email = System.Console.ReadLine();
            } while (!Regex.IsMatch(newCustomer.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"));

            
            /*
            do {
                System.Console.WriteLine("Enter your email:");
                newCustomer.Email = System.Console.ReadLine();
            } while (Regex.IsValidEmail(newCustomer.Email));

            
            System.Console.WriteLine("Enter a password:");
            string pwdFirstEntry = System.Console.ReadLine();
            System.Console.WriteLine("Reenter the same password:");
            string pwdSecondEntry = System.Console.ReadLine();
            if (pwdFirstEntry == pwdSecondEntry) {
                newCustomer.password = pwdSecondEntry;
            } else {

            }*/

            // TODO: Log that a new customer has been created, and push the details to the BL
            return newCustomer;



        }

        public static void SignUp()
        {
            // TODO: Implement Sign Up functionality
            // 1: Ask for email 
            // 2: check if email matches with any other customer
            // 3: ask for password, then name and address
        }

        public static void Login()
        {
            // TODO: Implement Login functionality for existing users
        }

    }
}