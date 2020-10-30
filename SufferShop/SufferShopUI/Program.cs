using Serilog;
using SufferShopDB;
using SufferShopDB.Models;
using SufferShopLib;
using SufferShopUI.Menus;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SufferShopUI
{
    public class Program
    {

        public static User CurrentUser;

        
        static void Main()
        {

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("log.txt",
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();


            if (Log.Logger != null) { Console.WriteLine("Logger is on, I think."); }


            //customers = GetSampleCustomers();

            Console.WriteLine("Welcome Friend! What would you like to do today?");

            IMenu startMenu = new StartMenu(new SufferShopContext());
            startMenu.Run();

        }

    }
}
