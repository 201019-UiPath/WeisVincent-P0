using System.Text.RegularExpressions;

namespace SufferShopLib.Validation
{
    public class IsOneDigitCondition : IInputCondition
    {
        public bool ValidateInput(string input)
        {

            return Regex.IsMatch(input, "^\\d{1}$");

        }
    }
}
