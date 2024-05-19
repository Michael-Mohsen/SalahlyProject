using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sala7ly.Core.Models
{
	public class Department
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }

		public virtual List<Admin> Admins { get; set; }
		public virtual List<Worker> Workers { get; set; }
	}
}
