using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationRP.Models
{
	public class Student
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Range(1,100)]
		public int Age { get; set; }
		[ForeignKey("Department")]
		public int DeptNo { get; set; }
		public Department Department { get; set; }
	}
}
