using System;
using System.Collections.Generic;
using System.Text;

namespace SufferShopLib.Validation
{
    public static class InputConditions
    {
        public static readonly List<IInputCondition> NameConditions = new List<IInputCondition>(2) {
            new NotEmptyInputCondition() , new IsTwoWordsCondition()
        };

        public static readonly List<IInputCondition> EmailConditions = new List<IInputCondition>(2) {
            new NotEmptyInputCondition() , new IsTwoWordsCondition()
        };

        public static readonly List<IInputCondition> PasswordConditions = new List<IInputCondition>(2)
        {
            new NotEmptyInputCondition() , new IsTwoWordsCondition()
        };


    }
}
