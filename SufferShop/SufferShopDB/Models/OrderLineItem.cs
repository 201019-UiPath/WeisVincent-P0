using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SufferShopDB.Models
{
    /// <summary>
    /// This model represents a join-table entry between an order and products in that order. 
    /// Each instance of this model represents the quantity of a single product in a single order.
    /// </summary>
    public class OrderLineItem
    {
        [Key]
        public int Id;

        [ForeignKey("Order")]
        public int OrderId;
        public Order Order;

        [ForeignKey("Product")]
        public int ProductId;
        public Product Product;

        [Column("product_quantity")]
        public int ProductQuantity;

        private OrderLineItem(int orderId, int productId, int quantityOfProduct)
        {
            OrderId = orderId;
            ProductId = productId;
            ProductQuantity = quantityOfProduct;
        }

        public OrderLineItem( Order order, Product product, int quantityOfProduct) : this(order.Id, product.Id, quantityOfProduct)
        {
            this.Product = product;

            this.Order = order;
        }
    }
}
