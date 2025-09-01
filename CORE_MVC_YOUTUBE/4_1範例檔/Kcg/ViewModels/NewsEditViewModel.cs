using Kcg.Dtos;
using Kcg.Models;

namespace Kcg.ViewModels
{
	public class NewsEditViewModel
	{
		public NewsEditDto News { get; set; }

		public List<Department> Departments { get; set; }
	}
}
