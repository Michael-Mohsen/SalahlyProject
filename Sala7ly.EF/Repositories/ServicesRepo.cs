using Sala7ly.Core.Interfaces;
using Sala7ly.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sala7ly.EF.Repositories
{
	public class ServicesRepo : BaseRepository<Services>, IServicesRepo
	{
		private readonly Sala7lyDbContext _context;

		public ServicesRepo(Sala7lyDbContext context) : base(context)
		{

		}

		//public IEnumerable<Services> SpecialMethod()
		//{
		//	throw new NotImplementedException();
		//}

		IEnumerator<Services> IServicesRepo.SpecialMethod()
		{
			throw new NotImplementedException();
		}
	}
}
