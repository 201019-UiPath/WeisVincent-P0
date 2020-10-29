namespace SufferShopDB.Models
{
    // TODO: Figure out how to make this enum work with the PostgreSQL DB
    public enum ProductType
    {
        Physical, Cognitive, Emotional, Metaphysical
    }
    public class Product
    {

        //TODO: Make constructor for Product.



        /*public Product(string name, double price, ProductType typeOfProduct, string description)
        {

        }*/

        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public ProductType TypeOfProduct { get; set; }

        public string Description { get; set; }



        //public List<LocationStockedProduct> LocationsStockedAt;









    }
}
