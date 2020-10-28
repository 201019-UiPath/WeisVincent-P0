using System.Text.RegularExpressions;

namespace SufferShopLib.Validation
{
    public class IsEmailCondition : IInputCondition
    {
        public bool ValidateInput(string input)
        {
            return Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        }
    }
}
