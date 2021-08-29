using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationRP.Models
{
	public class ApplicationUser:IdentityUser
	{
		[Range(1, 100)]
		public int Age { get; set; }
		public string ImagePath { get; set; }
		[ForeignKey("Department")]
		public int DeptNo { get; set; }
		public Department Department { get; set; }
		[NotMapped]
		public IFormFile Image { get; set; }
	}
}
