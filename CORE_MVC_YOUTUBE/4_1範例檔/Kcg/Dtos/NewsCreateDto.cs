namespace Kcg.Dtos
{
    public class NewsCreateDto
    {
    
        public string Title { get; set; }

        public string Contents { get; set; }
        public int DepartmentId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
     
      
    }
}
