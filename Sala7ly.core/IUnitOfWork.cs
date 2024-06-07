using Sala7ly.Core.Interfaces;
using Sala7ly.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sala7ly.Core
{
	public interface IUnitOfWork : IDisposable
	{
		//IBaseRepository<Admin> Admins { get; }
		IAdminsRepository Admins { get; }
		
		//IBaseRepository<Department> Departments { get; }
		IDepartmentsRepository Departments { get; }
		ISparePartsRepository SpareParts { get; }

		//Return number of row that affected with changes
		int Complete();

	}
}
