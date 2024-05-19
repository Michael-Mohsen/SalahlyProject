using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sala7ly.Core.Models
{
	public class Order
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey("Client")]
		public int ClientId { get; set; }

		[ForeignKey("SpareParts")]
		public int ItemId { get; set; }

		[Required(ErrorMessage = "Payment date is required.")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public DateTime OrderDate { get; set; } = DateTime.Now;

		public virtual Client Client { get; set; }
		public virtual SpareParts SpareParts { get; set; }
	}
}
