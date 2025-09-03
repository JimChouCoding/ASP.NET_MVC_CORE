using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kcg.Models;
using Kcg.Dtos;
using Kcg.ViewModels;
using Kcg.Services;
using Kcg.Interface;

namespace Kcg.Controllers
{
    public class NewsController : Controller
    {
        private readonly KcgContext _context;
        private readonly INewsService _newsService;
        private readonly DITransient _dITransient;
        private readonly DIScoped _dIScoped;
        private readonly DISingleton _dISingleton;

        public NewsController(KcgContext context, INewsService newsService, DITransient dITransient, DIScoped dIScoped, DISingleton dISingleton)
        {
            _context = context;
            _newsService = newsService;
            _dITransient = dITransient;
            _dIScoped = dIScoped;
            _dISingleton = dISingleton;
        }

        // GET: News
        public async Task<IActionResult> Index()
        {
            _dITransient.value = _dITransient.value + " >NewsController";
            _dIScoped.value = _dIScoped.value + " >NewsController";
            _dISingleton.value = _dISingleton.value + " >NewsController";

            var result = await _newsService.GetAllNewsAsync();

            ViewBag.DITransient = _dITransient.value;
            ViewBag.DIScoped = _dIScoped.value; 
            ViewBag.DISingleton = _dISingleton.value;
            return View(result);
        }

        // GET: News/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _newsService.取得新聞詳細資訊(id.Value);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: News/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewsCreateDto news)
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

                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var dto = await (from a in _context.News
                             where a.NewsId == id
                             select new NewsEditDto
                             {
                                 EndDateTime = a.EndDateTime,
                                 NewsId = a.NewsId,
                                 StartDateTime = a.StartDateTime,
                                 Title = a.Title,
                                 Contents = a.Contents,
                                 DepartmentId = a.DepartmentId,
                                 Enable = a.Enable
                             }).SingleOrDefaultAsync();

            if (dto == null) return NotFound();

            var vm = new NewsEditViewModel
            {
                News = dto,
                Departments = await _context.Department.ToListAsync()
            };

            return View(vm);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NewsEditViewModel vm)
        {
            // 🔑 這行確保 MVC 也去驗證內層的 NewsEditDto（包含 StartAndEnd）
            //TryValidateModel(vm.News, nameof(vm.News));

            if (!ModelState.IsValid)
            {
                // 驗證失敗 → 回填下拉清單再回 View
                vm.Departments = await _context.Department.ToListAsync();
                return View(vm);
            }

            var update = await _context.News.FindAsync(vm.News.NewsId);
            if (update == null) return NotFound();

            update.Title = vm.News.Title;
            update.Contents = vm.News.Contents;
            update.DepartmentId = vm.News.DepartmentId;
            update.StartDateTime = vm.News.StartDateTime;
            update.EndDateTime = vm.News.EndDateTime;
            update.Enable = vm.News.Enable;

            update.UpdateEmployeeId = 1;
            update.UpdateDateTime = DateTime.Now;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // GET: News/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.NewsId == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var news = await _context.News.FindAsync(id);
            if (news != null)
            {
                _context.News.Remove(news);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(Guid id)
        {
            return _context.News.Any(e => e.NewsId == id);
        }
    }
}
