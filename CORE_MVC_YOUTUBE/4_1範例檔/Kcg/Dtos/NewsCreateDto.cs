
using Kcg.Models;
using Kcg.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Kcg.Dtos
{
  
    public class NewsCreateDto :IValidatableObject
    {
        
        [Display(Name = "標題")]
        //[Required(ErrorMessage ="請輸入標題")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "內容")]
        public string Contents { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public List<IFormFile>? Files { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            KcgContext _kcgContext = (KcgContext)validationContext.GetService(typeof(KcgContext));

            var findTitle = from a in _kcgContext.News
                            where a.Title == Title
                            select a;

            if(Title == null)
            {
                yield return new ValidationResult("請輸入標題2", new[] { nameof(Title) });
            }

            if (findTitle.FirstOrDefault() != null)
            {
                yield return new ValidationResult("已存在相同的新聞標題", new[] { nameof(Title) });
            }

            if (StartDateTime > EndDateTime)
            {
                yield return new ValidationResult("開始日期不可大於結束日期", new[] { nameof(StartDateTime) });
            }
        }
    }
}
