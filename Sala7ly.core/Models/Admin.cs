using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sala7ly.Core.Models
{
	public class Admin
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public int Age { get; set; }
		[Required]
		[RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be 11 digits.")]
		public string Phone { get; set; }
		[Required]
		public Address HomeAddress { get; set; }

		[ForeignKey("Department")]
		public int DepartmentId { get; set; }
		public virtual Department Department { get; set; }
	}
}
