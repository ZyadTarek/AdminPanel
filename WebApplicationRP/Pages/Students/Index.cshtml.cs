using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationRP.Models;
using WebApplicationRP.Services;

namespace WebApplicationRP.Pages.Students
{
	[Authorize(Roles = "Admin")]
	public class IndexModel : PageModel
    {
		private IDBOperations<Student> _db;

		public List<Student> Students { get; set; }
		public IndexModel(IDBOperations<Student> db)
		{
			_db = db;
		}
		public void OnGet()
        {
			Students = _db.GetAll();
        }
    }
}
