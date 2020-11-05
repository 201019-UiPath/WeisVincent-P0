using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IceShopDB.Repos;

namespace IceShopWeb.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepository _repo;

        public CustomerController(IRepository repo)
        {
            _repo = repo;
        }

        // Use https://localhost:port/Customer/Index to use this function
        public async Task<IActionResult> Index()
        {
            return await GetAllCustomers();
        }

        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _repo.GetAllCustomersAsync();
            return View(customers);
        }

        public async Task<IActionResult> GetCustomerByEmail(string email)
        {
            var customer = await _repo.GetCustomerByEmailAsync(email);
            return View(customer);
        }

        
    }
}
