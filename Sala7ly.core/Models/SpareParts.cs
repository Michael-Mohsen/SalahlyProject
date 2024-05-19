using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sala7ly.Core.Models
{
	public class SpareParts
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required(ErrorMessage = "Price is required.")]
		public decimal Price { get; set; }
		[Required(ErrorMessage = "Amount is required.")]
		public int Amount { get; set; }
		[Required(ErrorMessage = "Payment date is required.")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public DateTime Date { get; set; } = DateTime.Now;
		[ForeignKey("Merchant")]
		public int MerchantId { get; set; }
		public virtual Merchant Merchant { get; set; }
		public virtual List<Order> Orders { get; set; }
	}
}
