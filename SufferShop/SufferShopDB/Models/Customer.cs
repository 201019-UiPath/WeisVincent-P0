﻿using System.Collections.Generic;

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
            Orders = new List<Order>();
        }




        public List<Order> Orders;

        public string Address { get; set; } //TODO: Add Address verification (https://salimadamoncrm.com/2018/05/24/bulk-address-validation-plugin-for-xrmtoolbox/)


    }
}
