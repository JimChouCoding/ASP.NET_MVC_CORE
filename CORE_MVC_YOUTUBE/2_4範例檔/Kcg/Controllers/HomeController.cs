using Kcg.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kcg.Controllers
{
    public class HomeController : Controller
    {
        private readonly KcgContext _kcgContext; //先在全域宣告資料庫物件

        public HomeController(KcgContext kcgContext) //這邊是依賴注入使用我們剛設定好的資料庫物件的寫法
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
