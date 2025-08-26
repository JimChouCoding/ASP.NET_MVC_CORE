using CustomerWebsite.Models;
using CustomerWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace CustomerWebsite.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		NorthwindContext _context;
		IMemoryCache _cache;

		public HomeController(ILogger<HomeController> logger, NorthwindContext context, IMemoryCache cache)
		{
			_logger = logger;
			_context = context;
			_cache = cache;
		}

		public IActionResult Index()
		{
			ViewBag.CustomerCountry = new SelectList(_context.Customers.Select(c => c.Country).Distinct());
			//ViewBag["CustomerCountry"] = new SelectList(_context.Customers.Select(c => c.Country).Distinct());
			ViewBag.Script = $"alert('客戶人數:){_context.Customers.Count()}";
			HttpContext.Session.SetString("SessionKey", "SessionValue");
			MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions();
			cacheOptions.SetSlidingExpiration(TimeSpan.FromDays(1));
			cacheOptions.SetPriority(CacheItemPriority.Normal);
			_cache.Set<string>("CacheKey", "CacheValue");
			CookieOptions cookieOptions = new CookieOptions();
			cookieOptions.Expires = DateTime.Now.AddYears(30);
			cookieOptions.Secure = true;
			cookieOptions.HttpOnly = true;
			Response.Cookies.Append("CookieKey", "CookieValue", cookieOptions);
			return View();        //Index.cshtml
		}

		public IActionResult Privacy()
		{
			string? SessionValue = HttpContext.Session.GetString("SessionKey");
			if (SessionValue != null) { }
			string? CacheValue = _cache.Get<string>("CacheKey");
			if (CacheValue != null) { }
			string? CookeieValue = Request.Cookies["CookieKey"];
			if (CookeieValue != null) { }
			return View();       //Privacy.cshtml
		}

		public IActionResult Customers()
		{
			//return View(_context.Customers);      //Customers.cshtml
			NorthwindContext context = new NorthwindContext();
			return View(context.Customers);
		}
		// GET : /Home/Contact
		[HttpGet]
		public IActionResult Contact()
		{
			return View();       //Contact.cshtml
		}

		// POST : /Home/Contact
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Contact([Bind("Name, Email, Phone")] ContactViewModel cvm) //明列所有可以接受的欄位
		{
			if(ModelState.IsValid) //通過Server端驗證
			{
				//寫入資料庫
				TempData["Message"] = "成功!";
				return RedirectToAction("Index", "Home");
			}
			return View(cvm);      //Contact.cshtml
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
