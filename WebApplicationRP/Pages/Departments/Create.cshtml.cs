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
    public class CreateModel : PageModel
    {
		private IDBOperations<Department> _deptdb;
		[BindProperty]
		public Department Department { get; set; }
		public CreateModel(IDBOperations<Department> deptdb)
		{
			_deptdb = deptdb;
		}
		public void OnGet()
        {  
        }
		public IActionResult OnPost()
		{
			if (ModelState.IsValid)
			{
				_deptdb.Add(Department);
				return RedirectToPage("/Departments/Index");
			}
			return Page();
		}
    }
}
