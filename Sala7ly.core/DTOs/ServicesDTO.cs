using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sala7ly.Core.DTOs
{
	public class ServicesDTO
	{
		[Required]
		public string ServiceName { get; set; }
	}
}
