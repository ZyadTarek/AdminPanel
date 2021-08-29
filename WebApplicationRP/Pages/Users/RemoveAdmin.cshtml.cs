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
    public class RemoveAdminModel : PageModel
    {
        private UserManager<IdentityUser> _userManager;
        private WebApplicationRPContext _db;

        public RemoveAdminModel(UserManager<IdentityUser> userManager, WebApplicationRPContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public RedirectResult OnGet(string id)
        {
            var admin = _userManager.FindByIdAsync(id).Result;
            var adminRole = _db.UserRoles.FirstOrDefault(u => u.UserId == admin.Id);
            _db.UserRoles.Remove(adminRole);
            _db.UserRoles.Add(new IdentityUserRole<string> { UserId = admin.Id, RoleId = "1" });
            _db.SaveChanges();
            //_userManager.RemoveFromRoleAsync(user, "User");
            //_userManager.AddToRoleAsync(user, "Admin");
            return Redirect("Index");
        }
    }
}
