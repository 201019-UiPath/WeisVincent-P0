namespace SufferShopModels
{
    public class Customer : User
    {
        public Customer(string name, string email, string password) : base(name, email, password)
        {

        }

        

        string address;

        public string Address { get; }


    }
}
