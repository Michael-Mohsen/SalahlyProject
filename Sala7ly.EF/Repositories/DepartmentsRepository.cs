using Sala7ly.Core.Interfaces;
using Sala7ly.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sala7ly.EF.Repositories
{
	public class DepartmentsRepository : BaseRepository<Department>, IDepartmentsRepository
	{
		private readonly Sala7lyDbContext _context;
		public DepartmentsRepository(Sala7lyDbContext context) : base(context)
		{
		}
		public IEnumerable<Department> SpecialMethod()
		{
			throw new NotImplementedException();
		}
	}
}
