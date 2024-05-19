using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sala7ly.Core.Models
{
	public class Merchant
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		[RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be 11 digits.")]
		public string Phone { get; set; }
		[Required]
		public Address ShopAddress { get; set; }

		public virtual List<SpareParts> SpareParts { get; set; }
	}
}
