﻿using SufferShopDB.Repos.DBRepos;
using System;
using System.Collections.Generic;
using System.Text;
using SufferShopBL;
using SufferShopDB.Models;
using SufferShopDB.Repos;

namespace SufferShopUI.Menus.ManagerMenus
{
    internal sealed class ManagerSignUpMenu : Menu, IMenu
    {
        private readonly IRepository Repo;
        private readonly LocationService locationService;

        List<Location> PossibleLocations;

        private Manager ManagerPickingALocation;



        public ManagerSignUpMenu(IRepository repo, Manager manager)
        {
            Repo = repo;
            locationService = new LocationService(Repo);

            PossibleLocations = locationService.GetAllLocations();
        }


        public override void SetStartingMessage()
        {
            StartMessage = "Which location are you manager for?";
        }

        public override void SetUserChoices()
        {
            
            PossibleOptions = new List<string>(PossibleLocations.Count);
            for (int i = 0; i < PossibleLocations.Count; i++)
            {
                PossibleOptions.Add($"{PossibleLocations[i].Name}  -  Located at: {PossibleLocations[i].Address}");
            }
        }


        public override void ExecuteUserChoice()
        {
            for (int i = 0; i < PossibleLocations.Count; i++)
            {
                if (selectedChoice != i + 1) continue;

                ManagerPickingALocation.Location = PossibleLocations[i];
                ManagerPickingALocation.LocationID = PossibleLocations[i].Id;

            }

            // At this point, the Run method should complete, 
            // and the ball SHOULD be thrown back to the SignUpMenu court and continue execution.
            LoginMenu loginMenu = new LoginMenu(Repo);
            MenuUtility.ReadyNextMenu(loginMenu);
        }

        public Manager RunAndReturnManagerWithSelectedLocation()
        {
            Run();
            return ManagerPickingALocation;
        }
        
    }
}
