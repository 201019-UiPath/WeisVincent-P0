using Serilog;
using IceShopDB;
using IceShopDB.Models;
using IceShopDB.Repos;
using IceShopDB.Repos.DBRepos;
using IceShopUI.Menus;
using System;
using System.Collections.Generic;

namespace IceShopUI
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

            IceShopContext context = new IceShopContext();
            IRepository repo = new DBRepo(context);
            IMenu startMenu = new StartMenu(ref repo);

            MenuUtility.Instance.ReadyNextMenu(startMenu);
            MenuUtility.Instance.RunThroughMenuChain();
        }

    }
}
