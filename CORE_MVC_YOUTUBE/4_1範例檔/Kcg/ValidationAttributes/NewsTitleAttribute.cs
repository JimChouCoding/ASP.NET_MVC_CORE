using Humanizer;
using Kcg.Dtos;
using Kcg.Models;
using System.ComponentModel.DataAnnotations;

namespace Kcg.ValidationAttributes
{
    public class NewsTitleAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            KcgContext _kcgContext = (KcgContext)validationContext.GetService(typeof(KcgContext));

            var title = (string)value;

            var findTitle = from a in _kcgContext.News
                            where a.Title == title
                            select a;
            var dto = validationContext.ObjectInstance;
            if (dto.GetType() == typeof(NewsEditDto))
            {
                var updateDto = (NewsEditDto)dto;
                findTitle = findTitle.Where(a => a.NewsId != updateDto.NewsId);
            }

            if (findTitle.FirstOrDefault() != null)
            {
                return new ValidationResult("已存在相同的新聞標題");
            }

            return ValidationResult.Success;
        }
    }
}
