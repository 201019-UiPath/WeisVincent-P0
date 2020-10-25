﻿using Xunit.Sdk;

namespace SufferShopBL.Validation
{
    public class NotEmptyInputCondition : IInputCondition
    {
        public bool ValidateInput(string input)
        {
            if (input.Equals(""))
            {
                throw new NotEmptyException();
            }
            else if (input == null)
            {
                throw new NullException(input);
            }
            else return true;

        }
    }
}