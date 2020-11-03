using SufferShopDB.Models;
using SufferShopDB.Repos;
using SufferShopLib.Validation;
using System;

namespace SufferShopBL
{
    public sealed class StartService
    {
        readonly IRepository Repo;

        readonly CustomerService customerService;
        readonly ManagerService managerService;

        public StartService(ref IRepository repo)
        {
            Repo = repo;
            customerService = new CustomerService(ref Repo);
            managerService = new ManagerService(ref Repo);
        }

        public static bool ValidateNameInput(string name)
        {
            InputValidator inputValidator = new InputValidator(InputConditions.NameConditions);
            return inputValidator.ValidateInput(name);
        }

        #region Input Validation
        public static bool ValidateEmailInput(string email)
        {
            InputValidator inputValidator = new InputValidator(InputConditions.EmailConditions);
            return inputValidator.ValidateInput(email);
        }

        public static bool ValidatePasswordInput(string password)
        {
            InputValidator inputValidator = new InputValidator(InputConditions.PasswordConditions);
            return inputValidator.ValidateInput(password);
        }

        public static bool ValidateAddressInput(string address)
        {
            InputValidator inputValidator = new InputValidator(InputConditions.AddressConditions);
            return inputValidator.ValidateInput(address);
        }

        #endregion

        #region Interaction with DB
        public User GetUserByEmail(string email)
        {

            Customer userAsCustomer = customerService.GetCustomerByEmail(email);
            Manager userAsManager = managerService.GetManagerByEmail(email);
            if (userAsCustomer == null)
            {
                if (userAsManager == null)
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
