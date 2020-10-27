using System.Collections.Generic;
using System.Data;

namespace SufferShopLib.Validation
{
    public class InputValidator
    {


        public InputValidator(string input, List<IInputCondition> conditions)
        {
            InputConditions = conditions;
            Input = input;
        }

        public InputValidator(string input, IInputCondition condition)
        {
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



        public string Input;

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



        public string ValidatedInput
        {
            get
            {
                if (InputIsValidated())
                {
                    return Input;
                }
                else
                {
                    return null;
                }
            }
        }


    }
}
