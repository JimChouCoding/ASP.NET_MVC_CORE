using Kcg.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kcg.Controllers
{
    public class HomeController : Controller
    {
        private readonly KcgContext _kcgContext; //���b����ŧi��Ʈw����

        public HomeController(KcgContext kcgContext) //�o��O�̿�`�J�ϥΧڭ̭�]�w�n����Ʈw���󪺼g�k
        {
            _kcgContext = kcgContext;
        }

        public string Index()
        {
            return _kcgContext.TOPMenu.FirstOrDefault().Name;
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
