using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // Get Home/Index
        [HttpGet]
		public IActionResult Index()
        {
            return View(); //Index.cshtml
        }
		// Post Home/Index
		[HttpPost]
       public IActionResult Index(int n)
       {
           return View(); //Index.cshtml
        }

        [HttpGet]
		public IActionResult Privacy()
        {
            //int x = 0;
            //int y = 0;
            //int z = y / x;
            return View(); //Privacy.cshtml
		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
