using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sala7ly.Core.Models
{
	public class Services
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string ServiceName { get; set; }
		
	}
}
