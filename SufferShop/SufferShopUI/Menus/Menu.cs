using SufferShopLib.Validation;
using System;
using System.Collections.Generic;
using Xunit.Sdk;

namespace SufferShopUI.Menus
{
    /// <summary>
    /// This class represents each menu in the system, using a Run() method to execute the 
    /// SetStartingMessage, SetUserChoices, Start, QueryUserChoice, and ExecuteUserChoice methods in that order.
    /// Each menu has a starting message to the user, lists off their choices, and takes in user input in the form of a number
    /// to determine which choice the user made.
    /// </summary>
    public abstract class Menu : IMenu
    {

        public string StartMessage;

        public abstract void SetStartingMessage();

        public abstract void SetUserChoices();

        public List<string> possibleOptions;
        public List<string> PossibleOptions
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


        public int selectedChoice;



        public void Run()
        {
            SetStartingMessage();
            SetUserChoices();
            Start();
            QueryUserChoice();
            ExecuteUserChoice();
        }



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
            if (PossibleOptions.Count < 10)
            {
                condition = new IsOneDigitCondition();
            }
            else
            {
                condition = new IsOneOrTwoDigitsCondition();
            }

            InputValidator validator = new InputValidator(condition);

            bool userInputIsInRange = false;
            do
            {
                string userInput = Console.ReadLine().Trim();
                while (!validator.ValidateInput(userInput))
                {
                    Console.WriteLine("That input wasn't it, sufferer. Give it another go, it needs to be a number.");
                    Start();
                    userInput = Console.ReadLine().Trim();
                }

                int userChoice = int.Parse(userInput);
                if (userChoice < 1 && userChoice > PossibleOptions.Count)
                {
                    Console.WriteLine("That input wasn't it, sufferer. Give it another go, it needs to be one of the offered choices.");
                    continue;
                } else
                {
                    userInputIsInRange = true;
                }
                selectedChoice = userChoice;
            } while (!userInputIsInRange);
            
            

        }


        public abstract void ExecuteUserChoice();


    }
}
