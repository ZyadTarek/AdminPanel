using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationRP.Models;
using WebApplicationRP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace WebApplicationRP.Pages.Users
{
	[Authorize(Roles ="Admin")]
    public class IndexModel : PageModel
    {
		private UserManager<IdentityUser> _userManager;
		private SignInManager<IdentityUser> _signInManager;
		private WebApplicationRPContext _db;
		public IList<ApplicationUser> Users { get; set; }
		public IList<ApplicationUser> Admins { get; set; }

		public IndexModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
			WebApplicationRPContext db)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			Users = new List<ApplicationUser>();
			Admins = new List<ApplicationUser>();
			_db = db;
		}
		public void OnGet()
		{
			var userRole = _db.Roles.Where(r => r.Id == "1").Select(r => r.Name).FirstOrDefault();
			var adminRole = _db.Roles.Where(r => r.Id == "2").Select(r => r.Name).FirstOrDefault();
		
			foreach (var user in _db.ApplicationUsers.Include(u => u.Department))
			{
				//var IsUser = _userManager.IsInRoleAsync(user, userRole).Result;
				//var IsAdmin = _userManager.IsInRoleAsync(user, adminRole).Result;
				if (_userManager.IsInRoleAsync(user, userRole).Result)
				{
					Users.Add(user as ApplicationUser);
				}
				if (_userManager.IsInRoleAsync(user, adminRole).Result)
				{
					Admins.Add(user as ApplicationUser);
				}
			}
			//Users = (IList<ApplicationUser>)_userManager.GetUsersInRoleAsync("User");
			//Admins = (IList<ApplicationUser>)_userManager.GetUsersInRoleAsync("Admin");
		}
	}
}
