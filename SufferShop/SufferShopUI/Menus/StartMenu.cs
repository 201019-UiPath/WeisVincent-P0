using SufferShopDB.Repos;
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

        public StartMenu(ref IRepository repo) : base(ref repo)
        {
            signupMenu = new SignUpMenu(ref Repo);
            loginMenu = new LoginMenu(ref Repo);
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
                    MenuUtility.Instance.ReadyNextMenu(signupMenu);
                    break;
                case 2:
                    MenuUtility.Instance.ReadyNextMenu(loginMenu);
                    break;
                default:
                    throw new NotImplementedException();
                    //break;
            }
        }




    }
}