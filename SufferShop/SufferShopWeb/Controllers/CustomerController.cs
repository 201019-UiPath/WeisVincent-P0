using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SufferShopWeb.Controllers
{
    public class CustomerController : Controller
    {
        // Use https://localhost:port/Customer/Index to use this function
        public string Index()
        {
            return "Welcome to the World of useless Customer strings. Brought to you by CustomerController.cs";
        }
    }
}
