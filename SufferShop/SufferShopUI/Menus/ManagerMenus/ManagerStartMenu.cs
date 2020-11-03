using Serilog;
using SufferShopDB.Models;
using SufferShopDB.Repos;
using System;
using System.Collections.Generic;

namespace SufferShopUI.Menus.ManagerMenus
{
    internal class ManagerStartMenu : Menu, IMenu
    {
        private readonly Manager CurrentManager;

        private IMenu NextMenu;
        internal ManagerStartMenu(Manager manager, ref IRepository repo) : base(ref repo)
        {
            CurrentManager = manager;
        }

        public override void SetStartingMessage()
        {
            if (CurrentManager.Location == null)
            {
                Console.WriteLine("damnit");
            }
            // TODO: Manager's location is null at this point. How do I fix that trash?
            StartMessage = $"{CurrentManager.Name}, provider of suffering at the {CurrentManager.Location.Name} branch! Welcome back! \n You may view the order history of your managed branch, or manage inventory!";
        }

        public override void SetUserChoices()
        {
            PossibleOptions = new List<string>() {
                "View Location Order History.",
                "Manage Inventory.",
                "Exit."
            };
        }

        public override void ExecuteUserChoice()
        {
            switch (selectedChoice)
            {
                case 1:
                    NextMenu = new ManagerLocationOrderHistoryMenu(CurrentManager, ref Repo);
                    break;
                case 2:
                    NextMenu = new ManagerInventoryManagementMenu(CurrentManager, ref Repo);
                    break;
                case 3:
                    Console.WriteLine("Done with your job already? See ya!");
                    return;
                //Environment.Exit(Environment.ExitCode);
                //break;
                default:
                    throw new NotImplementedException();
                    //break;
            }

            try
            {
                MenuUtility.Instance.ReadyNextMenu(NextMenu);
            }
            catch (NullReferenceException e)
            {
                Log.Error(e.Message);
            }
        }


    }
}
