using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationRP.Models;
using WebApplicationRP.Services;

namespace WebApplicationRP.Pages.Students
{
    public class CreateModel : PageModel
    {
		private IDBOperations<Department> _deptdb;
		private IDBOperations<Student> _stddb;

		[BindProperty]
		public Student Student { get; set; }
		public CreateModel(IDBOperations<Department> deptdb,IDBOperations<Student> stddb)
		{
			_deptdb = deptdb;
			_stddb = stddb;
		}
		public void OnGet()
        {
			SelectList s = new SelectList(_deptdb.GetAll(), "Id", "Name");
			ViewData["items"] = s;
        }
		public IActionResult OnPost()
		{
			if (ModelState.IsValid)
			{
				_stddb.Add(Student);
				return RedirectToPage("/students/index");
			}
			SelectList s = new SelectList(_deptdb.GetAll(), "Id", "Name",Student.DeptNo);
			ViewData["items"] = s;
			return Page();
		}
    }
}
