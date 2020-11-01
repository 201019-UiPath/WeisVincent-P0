using SufferShopDB.Models;
using SufferShopDB.Repos;

namespace SufferShopUI.Menus.ManagerMenus
{
    internal class ManagerLocationInventoryMenu : Menu, IMenu
    {
        private Manager currentManager;

        public ManagerLocationInventoryMenu(Manager currentManager, ref IRepository repo) : base(ref repo)
        {
            this.currentManager = currentManager;
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