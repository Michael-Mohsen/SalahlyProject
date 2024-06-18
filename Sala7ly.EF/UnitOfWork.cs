using Sala7ly.Core;
using Sala7ly.Core.Interfaces;
using Sala7ly.Core.Models;
using Sala7ly.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sala7ly.EF
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly Sala7lyDbContext _context;

		public IAdminsRepository Admins { get; private set; }

		public IDepartmentsRepository Departments { get; private set; }
		public ISparePartsRepository SpareParts { get; private set; }
		public IServicesRepo Services { get; private set; }
		public UnitOfWork(Sala7lyDbContext context)
		{
			_context = context;

			Admins = new AdminsRepository(_context);
			Departments = new DepartmentsRepository(_context);
			SpareParts = new SparePartsRepository(_context);
			Services = new ServicesRepo(_context);
		}

		//Return number of row that affected with changes
		public int Complete()
		{
			return _context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
