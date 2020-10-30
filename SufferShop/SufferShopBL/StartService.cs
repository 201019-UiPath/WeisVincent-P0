using SufferShopDB;
using SufferShopDB.Models;
using SufferShopDB.Repos.DBRepos;
using SufferShopLib.Validation;
using System;

namespace SufferShopBL
{
    public sealed class StartService
    {
        readonly CustomerService customerService = new CustomerService(new DBRepo(new SufferShopContext()));
        readonly ManagerService managerService = new ManagerService(new DBRepo(new SufferShopContext()));



        public StartService()
        {

        }

        public static bool ValidateNameInput(string name)
        {
            InputValidator inputValidator = new InputValidator();
            inputValidator.InputConditions = InputConditions.NameConditions;
            return inputValidator.ValidateInput(name);
        }

        #region Input Validation
        public static bool ValidateEmailInput(string email)
        {
            InputValidator inputValidator = new InputValidator();
            inputValidator.InputConditions = InputConditions.EmailConditions;
            return inputValidator.ValidateInput(email);
        }

        public static bool ValidatePasswordInput(string password)
        {
            InputValidator inputValidator = new InputValidator();
            inputValidator.InputConditions = InputConditions.PasswordConditions;
            return inputValidator.ValidateInput(password);
        }

        public static bool ValidateAddressInput(string address)
        {
            InputValidator inputValidator = new InputValidator();
            inputValidator.InputConditions = InputConditions.AddressConditions;
            return inputValidator.ValidateInput(address);
        }

        #endregion

        #region Interaction with DB
        public User GetUserByEmail(string email)
        {

            Customer userAsCustomer = customerService.GetCustomerByEmail(email);
            Manager userAsManager = managerService.GetManagerByEmail(email);
            if (userAsCustomer.Equals(null))
            {
                if (userAsManager.Equals(null))
                {
                    return null;
                }
                else
                {
                    return userAsManager;
                }
            }
            else
            {
                return userAsCustomer;
            }

        }


        #endregion





        public static Type GetTypeOfUser(User user)
        {
            if (user is Customer)
            {
                return typeof(Customer);
            }
            else if (user is Manager)
            {
                return typeof(Manager);
            }
            else { return null; }
        }

    }
}
