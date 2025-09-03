using Kcg.Dtos;
using Kcg.ViewModels;

namespace Kcg.Interface
{
    public interface INewsService
    {
        Task<List<NewsDto>> 取得新聞列表();

        Task<NewsDto> 取得新聞詳細資訊(Guid newsId);

        Task 新增(NewsCreateDto news);

        Task<NewsEditViewModel> 修改取得(Guid? id);

        Task 修改(Guid id, NewsEditDto news);

        Task 刪除(Guid id);
    }
}
