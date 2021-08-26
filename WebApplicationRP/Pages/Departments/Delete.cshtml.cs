using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationRP.Models;
using WebApplicationRP.Services;

namespace WebApplicationRP.Pages.Departments
{
    public class DeleteModel : PageModel
    {
		private IDBOperations<Department> _deptdb;
		[BindProperty]
		public Department Department { get; set; }
		public DeleteModel(IDBOperations<Department> deptdb)
		{
			_deptdb = deptdb;
		}
		public IActionResult OnGet(int id)
        {
			Department = _deptdb.getById(id);

			if (Department == null) return NotFound();
			return Page();
        }
		public IActionResult OnPost(int id)
		{
			return (_deptdb.Delete(id)) ? RedirectToPage("/Departments/Index") : RedirectToPage("/Departments/Details");
		}
    }
}
