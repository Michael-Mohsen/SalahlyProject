using Sala7ly.Core.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sala7ly.Core.Interfaces
{
	public interface IBaseRepository<T> where T:class
	{

		Task<T> GetByIdAsync(int id);

		Task<IEnumerable<T>> GetAllAsync();
		
		
		Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null);

		
		Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
		Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int skip, int take);
		Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? skip, int? take,
			Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending);


		Task<T> AddOneAsync(T entity);
		Task<IEnumerable<T>> AddListAsync(IEnumerable<T> entities);

		//T Update(T entity);
		Task<T> UpdateOneAsync(T entity);
		Task<IEnumerable<T>> UpdateListAsync(IEnumerable<T> entities);

		//void Delete(T entity);
		Task<T> DeleteOneAsync(T entity);
		Task<IEnumerable<T>> DeleteListAsync(IEnumerable<T> entities);
		//void DeleteRange(IEnumerable<T> entities);

		void Attach(T entity);

		//void AttachRange(IEnumerable<T> entities);

		Task<int> CountAsync();
		Task<int> CountAsync(Expression<Func<T, bool>> criteria);
	}
}
