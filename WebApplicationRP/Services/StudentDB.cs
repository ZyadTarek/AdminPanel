using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationRP.Data;
using WebApplicationRP.Models;

namespace WebApplicationRP.Services
{
	public class StudentDB : IDBOperations<Student>
	{
		private WebApplicationRPContext _db;

		public StudentDB(WebApplicationRPContext db)
		{
			_db = db;
		}
		public Student Add(Student t)
		{
			_db.Students.Add(t);
			_db.SaveChanges();
			return t;
		}

		public bool Delete(int id)
		{
			var student = _db.Students.Remove(_db.Students.FirstOrDefault(d => d.Id == id));
			_db.SaveChanges();
			return (student != null);
		}

		public Student Edit(Student t)
		{
			_db.Update(t);
			_db.SaveChanges();
			return t;
		}

		public List<Student> GetAll()
		{
			return _db.Students.Include(s=>s.Department).ToList();
		}

		public Student getById(int? id)
		{
			return _db.Students.Include(s => s.Department).FirstOrDefault(d => d.Id == id);
		}
	}
}
