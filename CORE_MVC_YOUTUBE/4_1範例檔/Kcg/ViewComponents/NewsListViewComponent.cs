using Kcg.Dtos;
using Kcg.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kcg.ViewComponents
{
    public class NewsListViewComponent : ViewComponent
    {
        private readonly KcgContext _context;
        public NewsListViewComponent(KcgContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var result = from a in _context.News
                         join b in _context.Department on a.DepartmentId equals b.DepartmentId
                         join c in _context.Employee on a.UpdateEmployeeId equals c.EmployeeId
                         select new NewsDto
                         {
                             Click = a.Click,
                             Enable = a.Enable,
                             EndDateTime = a.EndDateTime,
                             NewsId = a.NewsId,
                             StartDateTime = a.StartDateTime,
                             Title = a.Title,
                             UpdateDateTime = a.UpdateDateTime,
                             UpdateEmployeeName = c.Name,
                             DepartmentName = b.Name,
                             Contents = a.Contents
                         };
            return View(result);
        }
    }
}