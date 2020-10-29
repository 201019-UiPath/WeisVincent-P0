using SufferShopLib.Validation;
using System.Collections.Generic;

namespace SufferShopBL
{
    public sealed class SignUpService
    {

        InputValidator NameValidator;

        InputValidator EmailValidator;

        InputValidator PasswordValidator;

        public SignUpService()
        {

            NameValidator = new InputValidator(InputConditions.NameConditions);
            
            EmailValidator = new InputValidator(InputConditions.EmailConditions);
            
            PasswordValidator = new InputValidator(InputConditions.PasswordConditions);
            
        }
    }
}
