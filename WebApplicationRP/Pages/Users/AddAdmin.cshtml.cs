using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationRP.Data;
namespace WebApplicationRP.Pages.Users
{
    public class AddAdminModel : PageModel
    {
        private UserManager<IdentityUser> _userManager;
        private WebApplicationRPContext _db;

		public AddAdminModel(UserManager<IdentityUser> userManager,WebApplicationRPContext db)
		{
            _userManager = userManager;
            _db = db;
		}
        public RedirectResult OnGet(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            var userRole = _db.UserRoles.FirstOrDefault(u => u.UserId == user.Id);
            _db.UserRoles.Remove(userRole);
            _db.UserRoles.Add(new IdentityUserRole<string> { UserId = user.Id, RoleId = "2" });
            _db.SaveChanges();
            //_userManager.RemoveFromRoleAsync(user, "User");
            //_userManager.AddToRoleAsync(user, "Admin");
            return Redirect("Index");
        }
    }
}
