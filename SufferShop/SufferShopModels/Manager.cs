﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SufferShopModels
{
    //TODO: Add XML Documentation on Manager class
    public class Manager : User
    {

        public Manager(string name, string email, string password, Location managedLocation) : base(name, email, password)
        {
            this.managedLocation = managedLocation;
        }

        Location managedLocation;

    }
}
