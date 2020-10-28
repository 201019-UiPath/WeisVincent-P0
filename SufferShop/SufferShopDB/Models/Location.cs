using System;
using System.Collections.Generic;

namespace SufferShopDB.Models
{
    //TODO: Add XML Documentation on Location class
    public class Location : IStorableInRepo
    {
        // TODO: Create Location constructors
        int id;

        public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private string name;

        public Manager Manager { get; set; }//TODO: revisit

        public string Name { get { return name; } set { name = value; } }

        private string address;
        public string Address { get { return address; } set { address = value; } }

        public List<LocationStockedProduct> ProductStock;

        public Stack<Order> OrderHistory;


    }
}
