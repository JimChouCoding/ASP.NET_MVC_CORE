using System.Diagnostics;
using CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly Northwind2Context _northwind2Context;

        public HomeController(Northwind2Context northwind2Context, ILogger<HomeController> logger)
        {
            _northwind2Context = northwind2Context;
            _logger = logger;

        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public string Index()
        {
            return _northwind2Context.TOPMenu.FirstOrDefault().Name;
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
