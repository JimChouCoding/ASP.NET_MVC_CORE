using Kcg.Dtos;
using Kcg.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kcg.Controllers
{
    public class News2Controller : Controller
    {
        private readonly KcgContext _context;

        public News2Controller(KcgContext context)
        {
            _context = context;
        }

        public IActionResult Index([FromQuery]string keyword)
        {
         

            return View();
        }

        public IActionResult Create([FromRoute]string id, [FromQuery(Name ="id")]string id2)
        {
            ViewBag.Id = id;
            ViewBag.Id2 = id2;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]NewsCreateDto news)
        {
            if (ModelState.IsValid)
            {
                News insert = new News()
                {
                    Title = news.Title,
                    Contents = news.Contents,
                    DepartmentId = news.DepartmentId,
                    StartDateTime = news.StartDateTime,
                    EndDateTime = news.EndDateTime,
                    Click = 0,
                    Enable = true,
                    InsertEmployeeId = 1,
                    UpdateEmployeeId = 1
                };

                _context.News.Add(insert);

                await _context.SaveChangesAsync();

                foreach (var item in news.Files)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", item.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

    }
}
