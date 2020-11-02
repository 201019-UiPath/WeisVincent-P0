using SufferShopBL;
using SufferShopDB.Models;
using SufferShopDB.Repos;
using System.Collections.Generic;

namespace SufferShopUI.Menus.ManagerMenus
{
    internal sealed class ManagerSignUpMenu : Menu, IMenu
    {
        private readonly LocationService locationService;

        List<Location> PossibleLocations;

        private Manager ManagerPickingALocation;



        public ManagerSignUpMenu(ref IRepository repo, ref Manager manager) : base(ref repo)
        {
            locationService = new LocationService(ref Repo);
            ManagerPickingALocation = manager;
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
                ManagerPickingALocation.LocationId = PossibleLocations[i].Id;

            }

            // At this point, the Run method should complete, 
            // and the ball SHOULD be thrown back to the SignUpMenu court and continue execution.
            LoginMenu loginMenu = new LoginMenu(ref Repo);
            MenuUtility.Instance.ReadyNextMenu(loginMenu);
        }

        public Manager RunAndReturnManagerWithSelectedLocation()
        {
            Run();
            return ManagerPickingALocation;
        }

    }
}
