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
    public class EditModel : PageModel
    {
		private IDBOperations<Student> _stddb;
		private IDBOperations<Department> _deptdb;

		[BindProperty]
		public Student Student { get; set; }
		public EditModel(IDBOperations<Student> stddb,IDBOperations<Department>deptdb)
		{
            _stddb = stddb;
			_deptdb = deptdb;
		}
		public void OnGet(int id)
        {
			Student = _stddb.getById(id);
			SelectList s = new SelectList(_deptdb.GetAll(), "Id", "Name");
			ViewData["depts"] = s;
        }
		public IActionResult OnPost()
		{
			if (ModelState.IsValid)
			{
				_stddb.Edit(Student);
				return RedirectToPage("/Students/Index");
			}
			return Page();
		}
    }
}
