using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sala7ly.Core.Models
{
	public class ClientWorker
	{
		[Key]
		public int Id { get; set; }
		[ForeignKey("Client")]
		public int ClientId { get; set; }
		[ForeignKey("Worker")]
		public int WorkerId { get; set; }
		public virtual Client Client { get; set; }
		public virtual Worker Worker { get; set; }
	
	}
}
