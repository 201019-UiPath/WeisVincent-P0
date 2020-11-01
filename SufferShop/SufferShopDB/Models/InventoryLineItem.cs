using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SufferShopDB.Models
{

    /// <summary>
    /// This model represents a join-table entry between a location and products at that location. 
    /// Each instance of this model represents the quantity of a single product at a single location.
    /// </summary>
    public class InventoryLineItem
    {
        [Key]
        public int Id;

        [ForeignKey("Location")]
        public int LocationId;
        public Location Location;

        [ForeignKey("Product")]
        public int ProductId;
        public Product Product;

        [Column("ProductQuantity")]
        public int ProductQuantity;

        


        private InventoryLineItem(int locationId, int productId, int productQuantity)
        {
            this.ProductId = productId;
            this.ProductQuantity = productQuantity;
            this.LocationId = locationId;
        }

        public InventoryLineItem(Location location, Product product, int productQuantity) : this(location.Id, product.Id, productQuantity)
        {
            this.Product = product;
            this.Location = location;
        }


    }
}
