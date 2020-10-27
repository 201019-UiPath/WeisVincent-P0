using System;

namespace SufferShopDB.Models
{
    public abstract class User
    {

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        private readonly int id;

        public int ID
        {
            get
            {
                try
                {
                    return id;
                }
                catch
                {
                    throw new NotImplementedException("No functionality or access to set custom ID.");
                }

            }
        }

        public string Name { get; set; }
        public string Email { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        // TODO: Try using SecureString instead of string for user passwords.
        protected string Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PhoneNumber { get => PhoneNumber; set => PhoneNumber = value; }




    }
}
