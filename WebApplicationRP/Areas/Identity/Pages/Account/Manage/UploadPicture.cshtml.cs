using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationRP.Models;
using WebApplicationRP.Data;
using AzureServiceLayer;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace WebApplicationRP.Areas.Identity.Pages.Account.Manage
{
    public class UploadPictureModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private WebApplicationRPContext _db;
        private IConfiguration _configuration;
        private IHostingEnvironment _env;

        public UploadPictureModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            WebApplicationRPContext db,
            IConfiguration configuration,
            IHostingEnvironment env)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
            _configuration = configuration;
            _env = env;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Profile Picture")]
            public IFormFile Image { get; set; }

        }
        public async Task<IActionResult> OnGetAsync()
        {
             
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var input = Input;
            if (ModelState.IsValid)
            {
                var uploads = Path.Combine(_env.WebRootPath, "uploads");
                bool exists = Directory.Exists(uploads);
                if (!exists)
                    Directory.CreateDirectory(uploads);

                var fileName = Path.GetFileName(Input.Image.FileName);
                var fileStream = new FileStream(Path.Combine(uploads, Input.Image.FileName), FileMode.Create);
                string mimeType = Input.Image.ContentType.ToString();
                byte[] fileData = new byte[Input.Image.Length];

                BlobStorageService objBlobService = new BlobStorageService(_configuration);
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
                }
                var currentUser = (ApplicationUser)user;
                currentUser.ImagePath = objBlobService.UploadFileToBlob(Input.Image.FileName, fileData, mimeType);
                _db.SaveChanges();
                return Page();
            }
      
            return Page();
        }
    }
}