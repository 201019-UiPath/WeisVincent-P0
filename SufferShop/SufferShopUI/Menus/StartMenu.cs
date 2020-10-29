using SufferShopDB;
using SufferShopDB.Repos.DBRepos;
using System;
using System.Collections.Generic;

namespace SufferShopUI.Menus
{

    /// <summary>
    /// This is a sample menu to practice interfaces, menu creation, and XML documentation. This utilized the VSCode C# XML Documentation Extension:
    /// VS Marketplace Link: https://marketplace.visualstudio.com/items?itemName=k--kato.docomment
    /// </summary> 
    public sealed class StartMenu : Menu, IMenu
    {

        private readonly IMenu signupMenu;
        private readonly IMenu loginMenu;


        public StartMenu(SufferShopContext context)
        {
            signupMenu = new SignUpMenu(new DBRepo(context));
            signupMenu = new LoginMenu(new DBRepo(context));
        }


        #region Set up menu options
        public override void SetStartingMessage()
        {
            StartMessage = "Welcome! Please select which operation you'd like to perform!";
        }

        public override void SetUserChoices()
        {
            PossibleOptions = new List<string>() {
                "Sign-up for a new account.",
                "Log-in to an existing account."
            };
        }
        #endregion

        public override void ExecuteUserChoice()
        {
            switch (selectedChoice)
            {
                case 1:
                    signupMenu.Run();
                    break;
                case 2:
                    loginMenu.Run();
                    break;
                default:
                    throw new NotImplementedException();
                    break;
            }
        }




    }
}