using SufferShopLib;
using SufferShopUI.Menus;
using System;
using System.Collections.Generic;
using SufferShopModels;
using System.Diagnostics;
using Serilog.Core;
using Serilog;
using Serilog.Sinks.File;

namespace SufferShopUI
{
    public class Program
    {

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

            //Log.Logger = new LoggerConfiguration().WriteTo.File;

            Console.WriteLine("Welcome Friend! What would you like to do today?");

            if (Log.Logger != null && Debugger.IsAttached) { Console.WriteLine("Logger is on, I think."); }
            



            //customers = GetSampleCustomers();



            StartMenu startMenu = new StartMenu();

            startMenu.Run();

        }

    }
}
