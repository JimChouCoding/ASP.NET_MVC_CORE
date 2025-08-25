using System.ComponentModel.DataAnnotations;

namespace CustomerWebsite.ViewModels
{
	public class ContactViewModel
	{
		[Display(Name="姓名")]
		//[Required]
		public string Name { get; set; }
		[Display(Name = "電子郵件")]
		public string Email { get; set; }
		[Display(Name = "連絡電話")]
		public string Phone { get; set; }

	}
}