using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sala7ly.Core.Models
{
	public class Payment
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Price is required.")]
		public decimal Price { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public DateTime PaymentDate { get; set; } = DateTime.Now;

		[ForeignKey("Client")]
		public int ClientId { get; set; } // Foreign key
		public virtual Client Client { get; set; } // Navigation property
	}
}
