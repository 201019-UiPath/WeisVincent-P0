using System;
using System.Collections.Generic;
using System.Data;

namespace SufferShopLib.Validation
{
    /// <summary>
    /// This is an Input Validation class designed to work with any condition or number of conditions, defined in classes that implement IInputCondition.
    /// This class can be instantiated with any number of conditions greater than 0, and can then be used with the ValidateInput() method to validate a string against those conditions.
    /// </summary>
    public sealed class InputValidator
    {

        public InputValidator() : this(new NotEmptyInputCondition()) { }

        public InputValidator(List<IInputCondition> conditions)
        {
            InputConditions = conditions;
            Input = null;
        }

        public InputValidator(IInputCondition condition)
        {
            if (condition == null)
            {
                throw new Exception("No null elements allowed for the InputConditions in the InputValidator class.");
            }
            InputConditions = new List<IInputCondition>(1) { condition };
            Input = null;
        }

        public InputValidator(string input, List<IInputCondition> conditions)
        {
            InputConditions = conditions;
            Input = input;
        }


        public InputValidator(string input, IInputCondition condition)
        {
            if (condition == null)
            {
                throw new Exception("No null elements allowed for the InputConditions in the InputValidator class.");
            }
            InputConditions = new List<IInputCondition>(1) { condition };
            Input = input;
        }




        List<IInputCondition> inputConditions;
        public List<IInputCondition> InputConditions
        {
            get
            {
                return inputConditions;
            }
            set
            {
                if (value == null)
                {
                    throw new NoNullAllowedException();
                }
                else
                {
                    inputConditions = value;
                }
            }
        }



        public string Input { get; set; }

        public bool ValidateInput(string input)
        {
            Input = input;
            return InputIsValidated();
        }

        public bool InputIsValidated()
        {

            foreach (IInputCondition condition in InputConditions)
            {
                if (!condition.ValidateInput(Input))
                {
                    return false;
                }
            }

            return true;
        }



    }
}
