using System.Text.RegularExpressions;

namespace SufferShopLib.Validation
{
    public class IsOneOrTwoDigitsCondition : IInputCondition
    {
        public bool ValidateInput(string input)
        {
            if (Regex.IsMatch(input, "^\\d{2}$") || Regex.IsMatch(input, "^\\d{1}$"))
            {
                return true;
            }
            return false;

        }
    }
}
