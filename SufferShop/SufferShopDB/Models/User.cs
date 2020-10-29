using System.ComponentModel.DataAnnotations;

namespace SufferShopDB.Models
{
    public abstract class User
    {

        /*public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }*/



        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        // TODO: Try using SecureString instead of string for user passwords.
        public string Password { get; set; }


    }
}
