using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AuthWebSite.Data
{
	public class ApplicationUser : IdentityUser
	{
		[MaxLength(3)]
		public string? Country { get; set; } //nvarchar(max)

	}
}
