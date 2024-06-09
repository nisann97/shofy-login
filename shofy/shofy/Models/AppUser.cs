using System;
using Microsoft.AspNetCore.Identity;

namespace shofy.Models
{
	public class AppUser : IdentityUser
	{
		public string FullName { get; set; }
	}
}

