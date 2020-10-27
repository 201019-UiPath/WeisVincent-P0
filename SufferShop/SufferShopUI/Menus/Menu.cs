using SufferShopLib.Validation;
using System;
using System.Collections.Generic;
using Xunit.Sdk;

namespace SufferShopUI.Menus
{
    public abstract class Menu : IMenu
    {
        protected string StartMessage;

        protected List<string> possibleOptions;
        protected List<string> PossibleOptions
        {
            get
            {
                if (possibleOptions != null) return possibleOptions; else throw new NotNullException();
            }
            set
            {
                possibleOptions = value;
            }
        }
        protected int selectedChoice;



        public void Run()
        {
            Start();
            QueryUserChoice();
            ExecuteUserChoice();
        }

        public abstract void ExecuteUserChoice();

        public void Start()
        {
            Console.WriteLine(StartMessage);
            Console.WriteLine("Press the corresponding number to choose the option that best suits you.");
            for (int i = 0; i < PossibleOptions.Count; i++)
            {
                Console.WriteLine($"[{i + 1}]    {PossibleOptions[i]}");
            }


        }

        /// <summary>
        /// This method handles each interaction the user has with the menu.
        /// </summary>
        public void QueryUserChoice()
        {

            string userInput = Console.ReadLine().Trim();

            IInputCondition condition;
            if (PossibleOptions.Count >= 10)
            {
                condition = new IsOneDigitCondition();
            }
            else
            {
                condition = new IsTwoDigitsCondition();
            }

            InputValidator validator = new InputValidator(userInput, condition);


            if (validator.InputIsValidated())
            {

                int userChoice = int.Parse(userInput);
                selectedChoice = userChoice;

            }
            else
            {
                // TODO: Handle failed user inputs in menus.
                throw new NotImplementedException("QueryUserChoice() in SufferShopUI.Menus.Menu.cs does not handle failed user inputs yet.");
                Console.WriteLine("User input must be digits only.");

            }

        }




    }
}
