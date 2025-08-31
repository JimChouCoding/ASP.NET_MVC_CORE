using Microsoft.AspNetCore.Mvc;

namespace _3_3.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult View2()
        {
            return View();
        }
    }
}
