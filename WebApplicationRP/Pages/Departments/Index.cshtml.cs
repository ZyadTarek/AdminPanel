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
    public class IndexModel : PageModel
    {
		private IDBOperations<Department> _deptdb;
		public List<Department> Departments { get; set; }
		public IndexModel(IDBOperations<Department> deptdb)
		{
            _deptdb = deptdb;
		}
        public void OnGet()
        {
            Departments = _deptdb.GetAll();
        }
    }
}
