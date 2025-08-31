using Microsoft.AspNetCore.Mvc;

namespace _3_7.Controllers
{
    public class PayController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ATM()
        {
            //一些付款的程序

            //成功後留下成功字樣
            TempData["title"] = "使用ATM完成付款";
            return RedirectToAction("PayOK");
        }

        public IActionResult LinePay()
        {
            //一些付款的程序

            //成功後留下成功字樣
            TempData["title"] = "使用Line Pay完成付款。";
            return RedirectToAction("PayOK");
        }

        public IActionResult PayOK()
        {
            if (TempData["title"] == null)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
