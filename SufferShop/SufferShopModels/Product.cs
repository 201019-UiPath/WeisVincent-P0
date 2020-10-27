using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SufferShopModels
{
    public class Product
    {

        public enum ProductType
        {
            Physical, Mental, Metaphysical
        }

        public int ID { get; set; }

        
        public string Name { get; set; }

        
        public double Price { get; set; }
        
        
        public string TypeOfProduct { get; set; }

        
        public string Description { get; set; }


        public static ObservableCollection<Product> AllProducts = new ObservableCollection<Product>();



    }
}
