using Npgsql.TypeHandlers.NumericHandlers;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SufferShopDB.Models
{
    public enum ProductType
    {
        Physical, Cognitive, Emotional, Metaphysical
    }
    public class Product
    {

        //TODO: Make constructor for Product.

        public Product(string name, double price, ProductType typeOfProduct, string description)
        {

        }

        public int ID { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public ProductType TypeOfProduct { get; set; }

        public string Description { get; set; }

        public List<LocationStockedProduct> LocationsStockedAt;

        public static void AddProductToStock(Product addedProduct, Location targetLocation)
        {

        }







    }
}
