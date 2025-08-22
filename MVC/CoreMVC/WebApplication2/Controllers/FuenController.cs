using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
	public class FuenController : Controller
	{
		public IActionResult Index() //Action 函式
		{
			return View();          // index.cshtml
		}
	}
}
