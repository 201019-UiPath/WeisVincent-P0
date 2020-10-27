using System.Collections.Generic;

namespace SufferShopDB.Models
{
    //TODO: Add XML Documentation on Customer class
    public class Customer : User
    {

        /// <summary>
        /// Constructor for new customers
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public Customer(string name, string email, string password) : base(name, email, password)
        {
            Address = null;
            orderHistory = new List<Order>();
        }

        List<Order> orderHistory;

        public string Address { get; set; }


    }
}
