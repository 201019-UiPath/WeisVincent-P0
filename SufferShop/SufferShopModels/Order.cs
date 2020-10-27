using System;

namespace SufferShopModels
{
    public class Order : IStorableInRepo
    {

        // TODO: Add constructor for Order class




        int id;

        public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        int customerID;

        double subtotal;

        int locationID;

        DateTime orderPlacedTime;

        DateTime orderFulfilledTime;

        bool IsComplete
        {
            get
            {
                if (orderFulfilledTime != null) return true; else return false;


            }
        }







        /// <summary>
        /// This field represents the customer who placed the order.
        /// </summary>
        public Customer customerWhoPlacedOrder;

    }
}
