using SufferShopDB;
using SufferShopDB.Models;
using SufferShopDB.Repos.DBRepos;
using SufferShopLib.Validation;
using System;
using System.Collections.Generic;

namespace SufferShopBL
{
    public sealed class LoginService
    {
        CustomerService customerService = new CustomerService(new CustomerDBRepo(new SufferShopContext()));

        ManagerService managerService = new ManagerService(new ManagerDBRepo(new SufferShopContext()));

        InputValidator inputValidator;

        public LoginService()
        {
            inputValidator = new InputValidator(new NotEmptyInputCondition());
        }

        public bool ValidateEmailInput(string email)
        {
            inputValidator.InputConditions = InputConditions.EmailConditions;
            return inputValidator.ValidateInput(email);
        }

        public bool ValidatePasswordInput(string password)
        {
            inputValidator.InputConditions = InputConditions.PasswordConditions;
            return inputValidator.ValidateInput(password);
        }

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

        public Type GetTypeOfUser(User user)
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
