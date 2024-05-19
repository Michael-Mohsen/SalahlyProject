using Microsoft.EntityFrameworkCore;
using Sala7ly.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sala7ly.EF.Repositories
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		protected Sala7lyDbContext _context;
		public BaseRepository(Sala7lyDbContext context)
		{
			_context = context;
		}

		public IEnumerable<T> GetAll()
		{
			return _context.Set<T>().ToList();
		}

		public T GetById(int id)
		{
			return _context.Set<T>().Find(id);
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public T Find(Expression<Func<T, bool>> match)
		{
			return _context.Set<T>().SingleOrDefault(match);
		}


		public T Find(Expression<Func<T, bool>> match, string[] includes = null)
		{
			IQueryable<T> query = _context.Set<T>();
			if (includes != null)
			{
				foreach (var item in includes)
				{
					query = query.Include(item);
				}
			}
			return query.SingleOrDefault(match);
		}

		public IEnumerator<T> FindAll(Expression<Func<T, bool>> match, string[] includes = null)
		{
			IQueryable<T> query = _context.Set<T>();
			if (includes != null)
			{
				foreach (var item in includes)
				{
					query = query.Include(item);
				}
			}
			return query.Where(match).ToList().GetEnumerator();
		}
	}
}
