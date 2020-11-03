using SufferShopDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SufferShopBL
{
    public class StagedLineItem
    {
        public InventoryLineItem affectedInventoryLineItem;

        public Product Product;
        public int Quantity;
        public StagedLineItem(Product product, int quantity, InventoryLineItem affectedInventoryLineItem)
        {
            Product = product;
            Quantity = quantity;
            this.affectedInventoryLineItem = affectedInventoryLineItem;
        }

        public int GetNewQuantityOfAffectedInventoryLineItem()
        {
            return affectedInventoryLineItem.ProductQuantity - Quantity;
        }

    }
}
