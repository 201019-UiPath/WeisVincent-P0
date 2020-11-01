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



        public static List<Customer> GetSampleCustomers() {
            return new List<Customer>()
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
        }

        public static List<Product> GetSampleProducts()
        {
            return new List<Product>()
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
        }



        public static List<Manager> GetSampleManagers()
        {
            List<Location> sampleLocations = GetSampleLocations();
            return new List<Manager>() {
                new Manager("Tubular Tom", "reallycool@email.com", "IJustLikeTubes1", sampleLocations[0].Id ) {
                    Id = -11
                },
                new Manager("Vincent Weis", "sample@manager.com", "bestmanager", sampleLocations[1].Id) {
                    Id = -12
                },
                new Manager("Vacuous Rom", "spiderthing@lake.net", "IAmASpider3", sampleLocations[2].Id) {
                    Id = -13
                }
            };
        }

        public static List<Location> GetSampleLocations()
        {
            return new List<Location>() {
                new Location() {
                    Id = -1,
                    Name = "Hell",
                    Address = "Earth's core, presumably.",
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
        }


       

        private static double ReturnSampleTimeForOrder()
        {
            Random rand = new Random();
            int randomDay = rand.Next(1, 30);
            DateTime newDateTime = new DateTime(2020, 10, randomDay);

            var unixTime = newDateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); ;

            return unixTime.TotalSeconds;
        }

        public static List<Order> GetSampleOrders()
        {
            List<Customer> sampleCustomers = GetSampleCustomers();
            List<Location> sampleLocations = GetSampleLocations();
            return new List<Order>()
            {
                new Order(sampleCustomers[0].Id, sampleLocations[0].Id, sampleCustomers[0].Address, /*new List<OrderLineItem>() { OrderLineItems[0],OrderLineItems[1] },*/ 23, ReturnSampleTimeForOrder()) { Id = -1 },
                new Order(sampleCustomers[1].Id, sampleLocations[1].Id, sampleCustomers[1].Address, /*new List<OrderLineItem>() { OrderLineItems[2],OrderLineItems[3] },*/ 18, ReturnSampleTimeForOrder()) { Id = -2 },
                new Order(sampleCustomers[0].Id, sampleLocations[1].Id, sampleCustomers[0].Address, /*new List<OrderLineItem>() { OrderLineItems[4] },*/ 7, ReturnSampleTimeForOrder()) { Id = -3 },
                //TODO: Populate sample Orders
            };
        }

        public static List<InventoryLineItem> GetSampleInventoryLineItems()
        {
            List<Product> sampleProducts = GetSampleProducts();
            List<Location> sampleLocations = GetSampleLocations();
            return new List<InventoryLineItem>()
            {
                new InventoryLineItem(sampleLocations[0].Id, sampleProducts[0].Id, 5),
                new InventoryLineItem(sampleLocations[0].Id, sampleProducts[2].Id, 2),
                new InventoryLineItem(sampleLocations[1].Id, sampleProducts[1].Id, 3),
                new InventoryLineItem(sampleLocations[1].Id, sampleProducts[2].Id, 1),
                new InventoryLineItem(sampleLocations[2].Id, sampleProducts[0].Id, 12),
                // TODO: Populate sample stock items
            };
        }

        public static List<OrderLineItem> GetSampleOrderLineItems()
        {
            List<Product> sampleProducts = GetSampleProducts();
            List<Order> sampleOrders = GetSampleOrders();
            return new List<OrderLineItem>()
            {
                // First order, 1 burning, 2 sad puppy pics
                new OrderLineItem(sampleOrders[0].Id, sampleProducts[0].Id, 1),
                new OrderLineItem(sampleOrders[0].Id, sampleProducts[1].Id, 2),
                new OrderLineItem(sampleOrders[1].Id, sampleProducts[2].Id, 3),
                new OrderLineItem(sampleOrders[1].Id, sampleProducts[1].Id, 1),
                new OrderLineItem(sampleOrders[2].Id, sampleProducts[1].Id, 6),

                
            };
        }

    }





}
