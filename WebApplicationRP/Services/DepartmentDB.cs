using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationRP.Data;
using WebApplicationRP.Models;

namespace WebApplicationRP.Services
{
	public class DepartmentDB : IDBOperations<Department>
	{
		private WebApplicationRPContext _db;

		public DepartmentDB(WebApplicationRPContext db)
		{
			_db = db;
		}
		public Department Add(Department t)
		{
			_db.Departments.Add(t);
			_db.SaveChanges();
			return t;
		}

		public bool Delete(int id)
		{
			var dept = _db.Departments.Remove(_db.Departments.FirstOrDefault(d => d.Id == id));
			_db.SaveChanges();
			return (dept != null);
		}

		public Department Edit(Department t)
		{
		    _db.Update(t);
			_db.SaveChanges();
			return t;
		}

		public List<Department> GetAll()
		{
			return _db.Departments.Include(d => d.Students).ToList();
		}

		public Department getById(int? id)
		{
			return _db.Departments.Include(d=>d.Students).FirstOrDefault(d => d.Id == id);
		}
	}
}
