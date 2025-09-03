using Kcg.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Kcg.ValidationAttributes
{
    public class StartAndEndAttribute : ValidationAttribute
    {
        public string Value = "test";
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dto = (dynamic)value;

            if (dto.StartDateTime > dto.EndDateTime)
            {
                return new ValidationResult("開始日期不可大於結束日期");
            }

            return ValidationResult.Success; 
        }
    }
}
