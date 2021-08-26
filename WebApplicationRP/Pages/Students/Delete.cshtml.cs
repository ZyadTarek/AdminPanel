using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationRP.Models;
using WebApplicationRP.Services;

namespace WebApplicationRP.Pages.Students
{
    public class DeleteModel : PageModel
    {
		private IDBOperations<Student> _stddb;

		[BindProperty]
		public Student Student { get; set; }
		public DeleteModel(IDBOperations<Student> stddb)
		{
            _stddb = stddb;    
		}
		public IActionResult OnGet(int id)
        {
			Student = _stddb.getById(id);

			if (Student == null) return NotFound();
			return Page();
        }
		public IActionResult OnPost(int id)
		{
			var Student = _stddb.Delete(id);
			if (Student) return RedirectToPage("/Students/Index");
			return RedirectToPage("/Students/Details");
		}
    }
}
