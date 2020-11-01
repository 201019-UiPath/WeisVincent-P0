using SufferShopDB.Models;
using System;
using System.Collections.Generic;

namespace SufferShopDB.Repos
{
    /// <summary>
    /// Sample data class for development purposes only, before proper database usage is implemented. 
    /// Should not be utilized in final build.
    /// </summary>
    public static class SampleData
    {



        public readonly static List<Customer> Customers = new List<Customer>()
        {
            new Customer("Nick West","nevanwest@west.com","nevaniscool","Nick's house")
            {
                Id = -1
            },
            new Customer("Vincent Wees", "vincent.weis@revature.com", "password", "Vin's house")
            {
                Id = -2
            }
            //TODO: Populate sample customers
        };

        public readonly static List<Product> Products = new List<Product>()
        {
            new Product()
            {
                Id = -1,
                Name = "Burning",
                Price = 20.00,
                TypeOfProduct = ProductType.Physical,
                Description = "The sensation of being on fire, usually caused by being on fire.",

            },
            new Product()
            {
                Id = -2,
                Name = "Sad Puppy Picture",
                Price = 8.00,
                TypeOfProduct = ProductType.Emotional,
                Description = "They're really cute, actually, if your brain is messed up.",

            },
            new Product()
            {
                Id = -3,
                Name = "Spider Infestation",
                Price = 12.00,
                TypeOfProduct = ProductType.Metaphysical,
                Description = "Become Spiders-Man, and become a hive mind of spiders.",

            }
        };



        public readonly static List<Location> Locations = new List<Location>() {
            new Location() {
                Id = -1,
                Name = "Hell",
                Address = "Earth's core, presumably."
            },
            new Location() {
                Id = -2,
                Name = "Dirty Sock",
                Address = "In a laundry hamper"
            },
            new Location() {
                Id = -3,
                Name = "Phoenix",
                Address = "1 E Washington St., #230, Phoenix, AZ 85004"
            }
        };


        public readonly static List<Manager> Managers = new List<Manager>() {
            new Manager("Tubular Tom", "reallycool@email.com", "IJustLikeTubes1", Locations[0] ) {
                Id = -1
            },
            new Manager("Vincent Weis", "sample@manager.com", "bestmanager", Locations[1]) {
                Id = -2
            },
            new Manager("Vacuous Rom", "spiderthing@lake.net", "IAmASpider3", Locations[2]) {
                Id = -3
            }
        };

        private static double ReturnSampleTimeForOrder()
        {
            Random rand = new Random();
            int randomDay = rand.Next(1, 30);
            DateTime newDateTime = new DateTime(2020, 10, randomDay);

            var unixTime = newDateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); ;

            return unixTime.TotalSeconds;
        }

        public readonly static List<Order> Orders = new List<Order>()
        {
            new Order(Customers[0], Locations[0], /*new List<OrderLineItem>() { OrderLineItems[0],OrderLineItems[1] },*/ 23, ReturnSampleTimeForOrder()),
            new Order(Customers[1], Locations[1], /*new List<OrderLineItem>() { OrderLineItems[2],OrderLineItems[3] },*/ 18, ReturnSampleTimeForOrder()),
            new Order(Customers[0], Locations[1], /*new List<OrderLineItem>() { OrderLineItems[4] },*/ 7, ReturnSampleTimeForOrder()),
            //TODO: Populate sample Orders
        };

        public readonly static List<InventoryLineItem> InventoryLineItems = new List<InventoryLineItem>()
        {
            new InventoryLineItem(Locations[0], Products[0], 5),
            new InventoryLineItem(Locations[0], Products[2], 2),
            new InventoryLineItem(Locations[1], Products[1], 3),
            new InventoryLineItem(Locations[1], Products[2], 1),
            new InventoryLineItem(Locations[2], Products[0], 12),
            // TODO: Populate sample stock items
        };

        public readonly static List<OrderLineItem> OrderLineItems = new List<OrderLineItem>()
        {
            // First order, 1 burning, 2 sad puppy pics
            new OrderLineItem(Orders[0], Products[0], 1),
            new OrderLineItem(Orders[0], Products[1], 2),
            new OrderLineItem(Orders[1], Products[2], 3),
            new OrderLineItem(Orders[1], Products[1], 1),
            new OrderLineItem(Orders[2], Products[1], 6),

            // TODO: Populate sample OrderLineItems
        };

    }





}
