using SufferShopDB.Models;
using SufferShopDB.Repos;

namespace SufferShopUI.Menus.ManagerMenus
{
    internal class ManagerLocationInventoryMenu : Menu, IMenu
    {
        private Manager CurrentManager;
        private Location CurrentLocation;

        public ManagerLocationInventoryMenu(Manager currentManager, ref IRepository repo) : base(ref repo)
        {
            CurrentManager = currentManager;
            CurrentLocation = CurrentManager.Location;
        }

        public override void SetStartingMessage()
        {
            throw new System.NotImplementedException();
        }

        public override void SetUserChoices()
        {
            throw new System.NotImplementedException();
        }

        public override void ExecuteUserChoice()
        {
            throw new System.NotImplementedException();
        }

        
    }
}