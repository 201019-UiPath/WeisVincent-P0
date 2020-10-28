namespace SufferShopDB.Models
{

    /// <summary>
    /// This model represents a join-table entry between a location and products at that location. 
    /// Each instance of this model represents the quantity of a single product at a single location.
    /// </summary>
    public class LocationStockedProduct
    {
        

        public int ProductID;
        public Product Product;
        public int QuantityOfProduct;

        public int LocationID;
        public Location Location;

        public int OrderID;
        public Order Order;

        public LocationStockedProduct(Product product, int quantityOfProduct, Location location)
        {

            this.ProductID = product.ID;
            this.Product = product;
            this.QuantityOfProduct = quantityOfProduct;

            this.LocationID = location.ID;
            this.Location = location;

        }


    }
}
