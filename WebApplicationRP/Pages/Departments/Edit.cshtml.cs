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
    public class EditModel : PageModel
    {
		private IDBOperations<Department> _debptdb;
		[BindProperty]
		public Department Department { get; set; }
		public EditModel(IDBOperations<Department>deptdb)
		{
			_debptdb = deptdb;
		}
		public void OnGet(int id)
        {
			Department = _debptdb.getById(id);
        }
		public IActionResult OnPost()
		{
			if (ModelState.IsValid)
			{
				_debptdb.Edit(Department);
				return RedirectToPage("/departments/index");
			}
			return Page();
		}
    }
}
