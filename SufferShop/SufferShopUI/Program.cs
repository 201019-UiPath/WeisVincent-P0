using System;
using System.Collections.Generic;
using SufferShopDB;
using SufferShopLib;
using SufferShopUI.Menus;

namespace SufferShopUI
{
    class Program
    {

        

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        static List<CustomerSample> customers = new List<CustomerSample>();
        static List<CustomerSample> GetSampleCustomers(){
            List<CustomerSample> sampleList = new List<CustomerSample>();
            sampleList.Add(new CustomerSample(""));
            sampleList.Add(new CustomerSample("Loser Boboser"));
            sampleList.Add(new CustomerSample("Winner Bobinner Chicken Dinner"));
            return sampleList;
        }
        
        static void Main()
        {


            if (Logger != null) {Console.WriteLine("yes");}
            try{
                Logger.Info("Hello World");
                Console.WriteLine("oofsies");
            }
            catch (Exception ex) {
                Logger.Error(ex, "Goodbye cruel world");
                Console.WriteLine("okay");
            } finally {

            }
            

            customers = GetSampleCustomers();


            SampleCLIMainMenu.Start();
            CustomerSample newCustomer = SampleCLIMainMenu.GetCustomerDetails();
            System.Console.WriteLine($"New customer entry {newCustomer.Name} was created with the ID {newCustomer.ID}");

            customers.Add(newCustomer);


            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.ID} {customer.Name}");
            }


        }
        
    }
}
