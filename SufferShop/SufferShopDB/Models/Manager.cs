namespace SufferShopDB.Models
{
    //TODO: Add XML Documentation on Manager class
    public class Manager : User
    {
        
        public Manager(string name, string email, string password, Location managedLocation) : base(name, email, password)
        {
            this.Location = managedLocation;
            this.LocationID = managedLocation.ID;
        }

        public int LocationID;//TODO: Revisit

        public Location Location;

    }
}
