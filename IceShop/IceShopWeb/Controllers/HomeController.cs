using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IceShopWeb.Models;

namespace IceShopWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult Index(int id = -1, string name="defaultname")
        {

            ViewBag.id = id;
            ViewBag.name = name;


            // Passing viewdata to the Index.cshtml file
            Customer customer = new Customer() { Id = 1, alias = "The Ultimate Customer", name = "Mr. Customer" };
            ViewData["CustomerUsingViewData"] = customer;
            ViewBag.CustomerButInABag= customer;
            return View(customer);
        }

        // This following line of code is attribute-based routing.
        // Make sure it doesn't conflict with the conventional routing in the Startup.cs
        [Route(("Controller=Home/action=Privacy/"))]
        public IActionResult Privacy()
        {
            return View();
        }

        // You don't NEED to specify the action if it's in the right controller already.
        [HttpPost]
        [Route(("Controller=Home"))]
        public IActionResult About()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
