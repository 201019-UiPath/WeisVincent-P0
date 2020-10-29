using System;
using System.Collections.Generic;

namespace SufferShopDB.Models
{
    public class Order : IStorableInRepo
    {

        // TODO: Review constructor for Order class, you left good stuff in it

        /*public Order(Customer customer, IList<Product> products, Location locationPlaced)
        {
            this.CustomerId = customer.Id;
            this.Customer = customer;



            
            double total = 0;

            IList<Product> stagedProducts = new List<Product>(products);
            foreach (Product productEntry in products)
            {
                total += productEntry.Price;

                if (stagedProducts.Contains(productEntry)) { }
                else {
                    OrderedProducts.Add(new OrderedProduct(productEntry, 1, this));
                }
                
            }
            this.Subtotal = total;

            
            this.LocationPlaced = locationPlaced;

            this.OrderPlacedTime = DateTime.Now;
        }*/

        public int Id { get; set; }

        public int CustomerId;

        /// <summary>
        /// This field represents the customer who placed the order.
        /// </summary>
        public Customer Customer;

        public IList<OrderedProduct> OrderedProducts;

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
