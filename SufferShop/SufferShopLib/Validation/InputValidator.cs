using System;
using System.Collections.Generic;
using System.Data;

namespace SufferShopLib.Validation
{
    public sealed class InputValidator
    {

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
