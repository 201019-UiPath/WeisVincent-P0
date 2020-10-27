using Serilog;
using SufferShopDB.Models;
using SufferShopDB.Repos;
using SufferShopLib;
using SufferShopUI.Menus;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SufferShopUI
{
    public class Program
    {

        IRepository Repository = new SampleData();

        public static User CurrentUser;

        static List<CustomerSample> customers = new List<CustomerSample>();
        static List<CustomerSample> GetSampleCustomers()
        {
            List<CustomerSample> sampleList = new List<CustomerSample>();
            sampleList.Add(new CustomerSample(""));
            sampleList.Add(new CustomerSample("Loser Boboser"));
            sampleList.Add(new CustomerSample("Winner Bobinner Chicken Dinner"));
            return sampleList;
        }

        static void Main()
        {

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("log.txt",
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();


            if (Log.Logger != null && Debugger.IsAttached) { Console.WriteLine("Logger is on, I think."); }


            //customers = GetSampleCustomers();

            Console.WriteLine("Welcome Friend! What would you like to do today?");

            IMenu startMenu = new StartMenu();
            startMenu.Run();

        }

    }
}
