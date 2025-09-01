namespace Kcg.Dtos
{
    public class NewsEditDto
    {
        public Guid NewsId { get; set; }
        public string Title { get; set; }
        public string Contents{ get; set; }

        public int DepartmentId { get; set; }
		public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
   
        public bool Enable { get; set; }
    }
}
