using System;

namespace SufferShopModels
{
    public abstract class User: IAuthenticateable
    {

        public User(string name, string email, string password)
        {
            this.name = name;
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

        string email;

        string password;

    }
}
