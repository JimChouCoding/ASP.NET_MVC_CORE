using Kcg.Dtos;
using Kcg.Interface;
using Kcg.Models;
using Kcg.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Kcg.Services
{
    public class NewsService : INewsService
    {
        private readonly KcgContext _context;
        private readonly DITransient _dITransient;
        private readonly DIScoped _dIScoped;
        private readonly DISingleton _dISingleton;

        public NewsService(KcgContext context, DITransient dITransient, DIScoped dIScoped, DISingleton dISingleton)
        {
            _context = context;
            _dITransient = dITransient;
            _dIScoped = dIScoped;
            _dISingleton = dISingleton;
        }

        public async Task<List<NewsDto>> GetAllNewsAsync()
        {
            _dITransient.value = _dITransient.value + " >NewsService";
            _dIScoped.value = _dIScoped.value + " >NewService";
            _dISingleton.value = _dISingleton.value + " >NewsService";

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
                             DepartmentName = b.Name
                         };
            return await result.ToListAsync();
        }

        public Task 修改(Guid id, NewsEditDto news)
        {
            throw new NotImplementedException();
        }

        public Task<NewsEditViewModel> 修改取得(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task 刪除(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<NewsDto>> 取得新聞列表()
        {
            throw new NotImplementedException();
        }

        public async Task<NewsDto> 取得新聞詳細資訊(Guid newsId)
        {
            var result = from a in _context.News
                         join b in _context.Department on a.DepartmentId equals b.DepartmentId
                         join c in _context.Employee on a.UpdateEmployeeId equals c.EmployeeId
                         where a.NewsId == newsId
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

            //取得上傳資料的邏輯

            return await result.FirstOrDefaultAsync();
        }

        public Task 新增(NewsCreateDto news)
        {
            throw new NotImplementedException();
        }
    }
}
