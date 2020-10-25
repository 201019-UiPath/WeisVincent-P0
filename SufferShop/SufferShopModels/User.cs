using System;

namespace SufferShopModels
{
    public abstract class User : IAuthenticateable
    {

        public User(string name, string email, string password)
        {
            this.Name = name;
            this.email = email;
            this.password = password;
        }


        int id;

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



        string name;
        public string Name { get => name; set => name = value; }

        string email;
        public string Email { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        string password;
        public string Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PhoneNumber { get => phoneNumber; set => throw new NotImplementedException(); }
        

        string phoneNumber;
        public void AddPhoneNumber(string phonenumber)
        {
            throw new NotImplementedException();
        }

    }
}
