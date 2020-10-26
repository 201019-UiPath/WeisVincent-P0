using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SufferShopBL;
using SufferShopBL.Validation;
using SufferShopModels;

namespace SufferShopUI.Menus
{
    public delegate void MenuSequence(string[] possibleOptions);

    /// <summary>
    /// This is a sample menu to practice interfaces, menu creation, and XML documentation. This utilized the VSCode C# XML Documentation Extension:
    /// VS Marketplace Link: https://marketplace.visualstudio.com/items?itemName=k--kato.docomment
    /// </summary> 
    public class StartMenu : Menu, IMenu
    {
        
        public StartMenu()
        {
            StartMessage = "Welcome! Please select which operation you'd like to perform!";
            PossibleOptions = new List<string>() {
                "Sign-up for a new account.",
                "Log-in to an existing account."
            };
        }



        public override void ExecuteUserChoice()
        {
            switch (selectedChoice)
            {
                case 1: IMenu signUpMenu = new SignUpMenu();
                    signUpMenu.Run();
                    break;
                case 2: Login();
                    break;
                default: throw new NotImplementedException();
                    break;
            }
        }




        

        public static void Login()
        {
            // TODO: Implement Login functionality for existing users

            List<IInputCondition> nameValidationConditions = new List<IInputCondition>() { new NotEmptyInputCondition(), new IsTwoWordsCondition() };

            Console.WriteLine("Enter your name:");
            string inputName = Console.ReadLine().Trim();
            do
            {
                Console.WriteLine("Your input must have two words.");
                Console.WriteLine("Enter your name:");
                inputName = Console.ReadLine().Trim();
            } while (!new InputValidator(inputName, nameValidationConditions).InputIsValidated());


            List<IInputCondition> emailValidationConditions = new List<IInputCondition>() { new NotEmptyInputCondition(), new IsEmailCondition() };

            Console.WriteLine("Enter your email:");
            string inputEmail = Console.ReadLine().Trim();
            do
            {
                Console.WriteLine("Your input must be in email format.");
                Console.WriteLine("Enter your email:");
                inputEmail = Console.ReadLine().Trim();
            } while (!new InputValidator(inputEmail, emailValidationConditions).InputIsValidated());


            List<IInputCondition> passwordValidationConditions = new List<IInputCondition>() { new NotEmptyInputCondition() };
            Console.WriteLine("Enter your password:");
            string inputPassword = Console.ReadLine().Trim();
            do
            {
                Console.WriteLine("Your input must be non-empty.");
                Console.WriteLine("Enter your password:");
                inputPassword = Console.ReadLine().Trim();
            } while (!new InputValidator(inputPassword, passwordValidationConditions).InputIsValidated());
            
            
            
            //TODO: Check at Login() if the inputted email and password match any existing customer or Manager, then make the current user either customer or manager.
            
            
            
            Program.CurrentUser = new Customer("Sample Name", inputEmail, inputPassword);

            // TODO: Move to next menu.



        }

        
    }
}