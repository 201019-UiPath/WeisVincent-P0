using SufferShopLib.Validation;
using System;
using System.Collections.Generic;
using Xunit.Sdk;

namespace SufferShopUI.Menus
{
    public abstract class Menu : IMenu
    {

        protected string StartMessage;

        public abstract void SetStartingMessage();

        public abstract void SetUserChoices();

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
            SetStartingMessage();
            SetUserChoices();
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

            IInputCondition condition;
            if (PossibleOptions.Count >= 10)
            {
                condition = new IsOneDigitCondition();
            }
            else
            {
                condition = new IsOneOrTwoDigitsCondition();
            }

            InputValidator validator = new InputValidator(condition);
            
            
            string userInput = Console.ReadLine().Trim();
            while (!validator.ValidateInput(userInput))
            {
                Console.WriteLine("That input wasn't it, sufferer. Give it another go, it needs to be a number.");
                Start();
                userInput = Console.ReadLine().Trim();
            }

            int userChoice = int.Parse(userInput);
            selectedChoice = userChoice;

        }


    }
}
