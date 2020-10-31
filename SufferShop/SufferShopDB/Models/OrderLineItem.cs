namespace SufferShopDB.Models
{
    /// <summary>
    /// This model represents a join-table entry between an order and products in that order. 
    /// Each instance of this model represents the quantity of a single product in a single order.
    /// </summary>
    public class OrderLineItem
    {
        public int ProductId;
        public Product Product;
        public int QuantityOfProduct;

        public int OrderId;
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
