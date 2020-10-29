namespace SufferShopDB.Models
{
    /// <summary>
    /// This model represents a join-table entry between an order and products in that order. 
    /// Each instance of this model represents the quantity of a single product in a single order.
    /// </summary>
    public class OrderedProduct
    {
        public int ProductID;
        public Product Product;
        public int QuantityOfProduct;

        public int OrderID;
        public Order Order;

        /*public OrderedProduct(Product product, int quantityOfProduct, Order order)
        {

            this.ProductID = product.Id;
            this.Product = product;
            this.QuantityOfProduct = quantityOfProduct;

            this.OrderID = order.Id;
            this.Order = order;

        }*/
    }
}
