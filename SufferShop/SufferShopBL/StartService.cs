using Serilog;
using SufferShopDB.Models;
using SufferShopDB.Repos;
using SufferShopLib.Validation;
using System;

namespace SufferShopBL
{
    /// <summary>
    /// This class handles sign-in and log-in business logic for the SufferShop using a repository that implements IRepository.
    /// This is where all authentication requests, sign-ups, and sign-ins are born and die.
    /// </summary>
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
            Log.Logger.Information("Validating the input of a name..");
            InputValidator inputValidator = new InputValidator(InputConditions.NameConditions);
            return inputValidator.ValidateInput(name);
        }

        #region Input Validation
        public static bool ValidateEmailInput(string email)
        {
            Log.Logger.Information("Validating the input of an email..");
            InputValidator inputValidator = new InputValidator(InputConditions.EmailConditions);
            return inputValidator.ValidateInput(email);
        }

        public static bool ValidatePasswordInput(string password)
        {
            Log.Logger.Information("Validating the input of a password..");
            InputValidator inputValidator = new InputValidator(InputConditions.PasswordConditions);
            return inputValidator.ValidateInput(password);
        }

        public static bool ValidateAddressInput(string address)
        {
            Log.Logger.Information("Validating the input of an address..");
            InputValidator inputValidator = new InputValidator(InputConditions.AddressConditions);
            return inputValidator.ValidateInput(address);
        }

        #endregion

        #region Interaction with DB
        public User GetUserByEmail(string email)
        {
            Log.Logger.Information("Retrieving a user by their email by querying both the Customer and Manager collections in the repository..");
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
