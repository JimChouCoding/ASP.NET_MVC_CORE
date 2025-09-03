using Kcg.Dtos;
using Kcg.Interface;
using Kcg.Models;
using Kcg.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Kcg.Services
{
    public class NewsSqlService : INewsService
    {
        private readonly KcgContext _context;

        public NewsSqlService(KcgContext context)
        {
            _context = context;
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

        public async Task<List<NewsDto>> 取得新聞列表()
        {
            string sql = @"SELECT a.Click,
                           a.Enable,
                           a.EndDateTime,
                           a.NewsId,
                           a.StartDateTime,
                           Title = a.Title + 'sql',
                           a.UpdateDateTime
                           FROM News a";

            var result = await _context.News.FromSqlRaw(sql)
                .Select(x => new NewsDto
                {
                    Click = x.Click,
                    Enable = x.Enable,
                    EndDateTime = x.EndDateTime,
                    NewsId = x.NewsId,
                    StartDateTime = x.StartDateTime,
                    Title = x.Title,
                    UpdateDateTime = x.UpdateDateTime
                }).ToListAsync();

            return result;
        }

        public Task<NewsDto> 取得新聞詳細資訊(Guid newsId)
        {
            throw new NotImplementedException();
        }

        public Task 新增(NewsCreateDto news)
        {
            throw new NotImplementedException();
        }
    }
}
