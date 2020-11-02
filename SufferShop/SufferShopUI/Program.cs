using Serilog;
using SufferShopDB;
using SufferShopDB.Models;
using SufferShopDB.Repos;
using SufferShopDB.Repos.DBRepos;
using SufferShopUI.Menus;
using System;
using System.Collections.Generic;
using System.IO;

namespace SufferShopUI
{
    public class Program
    {

        public static User CurrentUser;

        public static Queue<IMenu> MenuChain;

        static void Main()
        {

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("logs/log.txt",
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();


            if (Log.Logger == null) { throw new Exception("Logger isn't working."); }


            Console.WriteLine("Welcome Friend! What would you like to do today?");

            SufferShopContext context = new SufferShopContext();
            IRepository repo = new DBRepo(context);
            IMenu startMenu = new StartMenu(repo);

            MenuUtility.Instance.ReadyNextMenu(startMenu);
            MenuUtility.Instance.RunThroughMenuChain();
        }

    }
}
