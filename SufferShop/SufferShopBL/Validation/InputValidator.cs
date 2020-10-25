using SufferShopBL.Validation;
using System;
using System.Collections.Generic;
using System.Data;

namespace SufferShopBL
{
    public class InputValidator
    {


        public InputValidator(string input, List<IInputCondition> conditions)
        {
            this.InputConditions = conditions;
            this.Input = input;
        }

        public InputValidator(string input, IInputCondition condition)
        {
            this.InputConditions = new List<IInputCondition>(1) { condition };
            this.Input = input;
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
                if (!condition.ValidateInput(this.Input))
                {
                    return false;
                }
            }

            return true;
        }



        public string ValidatedInput 
        { get
            {
                if (InputIsValidated())
                {
                    return Input;
                } else
                {
                    return null;
                }
            } 
        }


    }
}
