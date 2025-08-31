using Kcg.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kcg.Controllers
{
    public class DemoController : Controller
    {
        private readonly KcgContext _kcgContext;

        public DemoController(KcgContext kcgContext)
        {
            _kcgContext = kcgContext;
        }
        public IActionResult Index()
        {
            //var model = _kcgContext.TOPMenu.FirstOrDefault();
            //return View(model);
            ViewData["Title"] = "這是從Controller就設定的值";
            ViewBag.title = "這也是從Controller就設定的值";


            return View();
        }

        public IActionResult View2()
        {
            return View();
        }
    }
}
