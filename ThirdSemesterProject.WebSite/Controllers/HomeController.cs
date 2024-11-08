using APIClient;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ThirdSemesterProject.WebSite.Models;

namespace ThirdSemesterProject.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IAPIClient _client;


        public HomeController(ILogger<HomeController> logger, IAPIClient client)
        {
            _logger = logger;
            _client = client;
        }

        

        public IActionResult Index()
        {
            return View(_client.GetAllProductsAsync());
        }

        public IActionResult Privacy()
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
