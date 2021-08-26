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
    public class DetailsModel : PageModel
    {
		private IDBOperations<Student> _stddb;
		[BindProperty]
        public Student Student { get; set; }
		public DetailsModel(IDBOperations<Student> stddb)
		{
            _stddb = stddb;
		}
        public void OnGet(int id)
        {
            Student = _stddb.getById(id);
        }
    }
}
