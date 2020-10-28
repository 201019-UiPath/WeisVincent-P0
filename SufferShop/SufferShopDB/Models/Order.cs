using System;
using System.Collections.Generic;

namespace SufferShopDB.Models
{
    public class Order : IStorableInRepo
    {

        // TODO: Add constructor for Order class

        public Order(Customer customer, IList<LocationStockedProduct> products, Location locationPlaced, DateTime orderPlacedTime)
        {
            this.CustomerID = customer.ID;
            this.Customer = customer;

            this.OrderedProducts = products;
            this.LocationPlaced = locationPlaced;
            this.OrderPlacedTime = orderPlacedTime;

            double total = 0;
            foreach (LocationStockedProduct productEntry in OrderedProducts)
            {
                total += productEntry.Product.Price;
            }
            this.Subtotal = total;

        }

        public int ID { get; set; }

        public int CustomerID;

        /// <summary>
        /// This field represents the customer who placed the order.
        /// </summary>
        public Customer Customer;

        public IList<LocationStockedProduct> OrderedProducts;

        public double Subtotal;

        public Location LocationPlaced;

        public DateTime OrderPlacedTime;

        public DateTime OrderFulfilledTime;

        bool IsComplete
        {
            get
            {
                if (OrderFulfilledTime != null) return true; else return false;


            }
        }

    }
}
