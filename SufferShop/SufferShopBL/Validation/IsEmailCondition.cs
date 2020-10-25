using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SufferShopBL.Validation
{
    public class IsEmailCondition : IInputCondition
    {
        public bool ValidateInput(string input)
        {

            return Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        }
    }
}
