using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sala7ly.Core.Models
{
	public class Worker
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		[RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be 11 digits.")]
		public string Phone { get; set; }
		[Required]
		[Range(15, 100, ErrorMessage = "Age must be between 15 and 100.")]
		public int Age { get; set; }
		[Required]
		public Address HomeAddress { get; set; }
		[ForeignKey("Department")]
		public int DepartmentId { get; set; }
		public virtual Department Department { get; set; }
		public virtual List<ClientWorker> ClientWorkers { get; set; }
	}
}
