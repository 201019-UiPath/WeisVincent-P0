using SufferShopDB.Models;
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
            new Customer()
            {
                Id = -1,
                Name = "Nick West",
                Email = "nevanwest@west.com",
                Password = "nevaniscool",
                Address = "Nick's house"
            },
            new Customer()
            {
                Id = -2,
                Name = "Vincent Wees",
                Email = "vincent.weis@revature.com",
                Password = "password",
                Address = "Vin's house"
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
                Name = "Sad Puppy Pictures",
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
                Name = "A Dirty Sock",
                Address = "In a laundry hamper"
            },
            new Location() {
                Id = -3,
                Name = "Phoenix",
                Address = "1 E Washington St., #230, Phoenix, AZ 85004"
            }
        };


        public readonly static List<Manager> Managers = new List<Manager>() {
            new Manager() {
                Id = -1,
                Name = "Tubular Tom",
                Email = "reallycool@email.com",
                Password = "IJustLikeTubes1",
                Location =  Locations[0],
            },
            new Manager() {
                Id = -2,
                Name = "Vincent Weis",
                Email = "sample@manager.com",
                Password = "bestmanager",
                Location =  Locations[1],
            },
            new Manager() {
                Id = -3,
                Name = "Vacuous Rom",
                Email = "spiderthing@lake.net",
                Password = "IAmASpider3",
                Location =  Locations[2],
            }
        };

        public readonly static List<Order> Orders = new List<Order>()
        {
            //TODO: Populate sample Orders
        };

        public readonly static List<LocationStockedProduct> ProductStock = new List<LocationStockedProduct>()
        {
            // TODO: Populate sample stock items
        };


    }





}
