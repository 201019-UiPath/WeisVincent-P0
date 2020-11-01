﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SufferShopDB.Models
{
    //TODO: Add XML Documentation on Manager class
    public class Manager : User
    {


        private Manager(string name, string email, string password, int locationId) : base(name, email, password)
        {
            LocationId = locationId;
        }

        /// <summary>
        /// This constructor should only be used for signup before a manager has selected a location to manage. 
        /// Managers should always have a Location to manage.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public Manager(string name, string email, string password) : base(name, email, password)
        {

        }

        public Manager(string name, string email, string password, Location managedLocation) : base(name, email, password)
        {
            this.Location = managedLocation;
            this.LocationId = managedLocation.Id;
        }

        [ForeignKey("Location")]
        public int LocationId;

        public Location Location;

    }
}
