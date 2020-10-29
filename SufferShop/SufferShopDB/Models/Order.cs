using System;
using System.Collections.Generic;

namespace SufferShopDB.Models
{
    public class Order : IStorableInRepo
    {

        // TODO: Add constructor for Order class

        public Order(Customer customer, IList<LocationStockedProduct> products, Location locationPlaced)
        {
            this.CustomerId = customer.Id;
            this.Customer = customer;

            this.OrderedProducts = products;
            this.LocationPlaced = locationPlaced;


            double total = 0;
            foreach (LocationStockedProduct productEntry in OrderedProducts)
            {
                total += productEntry.Product.Price;
            }
            this.Subtotal = total;

            this.OrderPlacedTime = DateTime.Now;
        }

        public int Id { get; set; }

        public int CustomerId;

        /// <summary>
        /// This field represents the customer who placed the order.
        /// </summary>
        public Customer Customer;

        public IList<LocationStockedProduct> OrderedProducts;

        public Location LocationPlaced;

        public double Subtotal { get; }

        public string Address;//TODO: Add address verification (https://salimadamoncrm.com/2018/05/24/bulk-address-validation-plugin-for-xrmtoolbox/)

        public DateTime OrderPlacedTime;

        public DateTime OrderFulfilledTime;//TODO: What the hell do I do about fulfillment?



        public bool IsComplete
        {
            get
            {
                if (OrderFulfilledTime != null) return true; else return false;


            }
        }


    }
}
