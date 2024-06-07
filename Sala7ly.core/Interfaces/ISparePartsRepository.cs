using Sala7ly.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sala7ly.Core.Interfaces
{
	public interface ISparePartsRepository : IBaseRepository<SpareParts>
	{
		IEnumerable<SpareParts> SpecialMethod();
	}
}
