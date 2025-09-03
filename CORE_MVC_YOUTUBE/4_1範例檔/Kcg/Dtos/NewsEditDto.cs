using Kcg.ValidationAttributes;
using Newtonsoft.Json.Linq;

namespace Kcg.Dtos
{
    [StartAndEnd(Value = "'這是傳值'")]
    public class NewsEditDto
    {
        public Guid NewsId { get; set; }
        [NewsTitle]
        public string Title { get; set; }
        public string Contents { get; set; }
        public int DepartmentId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
       
        public bool Enable { get; set; }
    }
}
