namespace SufferShopDB.Models
{
    //TODO: Add XML Documentation on Location class
    public class Location : IStorableInRepo
    {
        // TODO: Create Location constructors

        /*public Location(string name, string address)
        {
            Name = name;
            Address = address;
        }*/

        public int Id { get; set; }

        //public List<Manager> Managers { get; set; }//TODO: revisit

        public string Name { get; set; }

        public string Address { get; set; }


        //public List<LocationStockedProduct> ProductStock;

        //public Stack<Order> OrderHistory;


    }
}
