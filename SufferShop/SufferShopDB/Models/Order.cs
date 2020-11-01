using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SufferShopDB.Models
{
    [Table("Orders")]
    public class Order : IStorableInRepo
    {

        // TODO: Review constructor for Order class, you left good stuff in it

        private Order(int customerId, string address, int locationId, double subtotal, double timeOrderWasPlacedAsInt)
        {
            //TODO: How to deal with Order Id
            this.CustomerId = customerId;
            this.Address = address;
            this.LocationId = locationId;
            this.Subtotal = subtotal;
            this.TimeOrderWasPlaced = timeOrderWasPlacedAsInt;
        }

        public Order(Customer customer, Location locationPlaced, double subtotal, double timeOrderWasPlaced)
            : this(customer.Id, locationPlaced.Address, locationPlaced.Id, subtotal, timeOrderWasPlaced)
        {
            this.Customer = customer;

            this.Location = locationPlaced;

            this.OrderLineItems = new List<OrderLineItem>();

            this.TimeOrderWasPlaced = timeOrderWasPlaced;
            this.TimeOrderWasFulfilled = -1;
        }

        public Order(Customer customer, Location locationPlaced, List<OrderLineItem> orderLineItems, double subtotal, double timeOrderWasPlaced) 
            : this(customer, locationPlaced, subtotal, timeOrderWasPlaced)
        {
            this.OrderLineItems = orderLineItems;
        }



        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId;

        /// <summary>
        /// This field represents the customer who placed the order.
        /// </summary>
        public Customer Customer;

        [Column("Address")]
        public string Address;

        
        

        [ForeignKey("Location")]
        public int LocationId;
        public Location Location;

        public List<OrderLineItem> OrderLineItems;

        public void AddLineItemToOrder(OrderLineItem addedLineItem)
        {
            OrderLineItems.Add(addedLineItem);
        }

        [Column("Subtotal")]
        public double Subtotal { get; }


        /// <summary>
        /// This field represents the time the order was placed in Linux Epoch format. Should be in UTC, and converted when displayed in UI.
        /// Methods responsible for this should be in the DateTimeUtility class of the SufferShopLib assembly.
        /// </summary>
        [Column("placedtime_posix")]
        public double TimeOrderWasPlaced;

        [Column("finishedtime_posix")]
        public double TimeOrderWasFulfilled;//TODO: What the hell do I do about fulfillment?

        [NotMapped]
        public bool IsComplete
        {
            get
            {
                if (TimeOrderWasFulfilled > TimeOrderWasPlaced) return true; else return false;


            }
        }


    }
}
