using Microsoft.EntityFrameworkCore;
using Sala7ly.Core.Consts;
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

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task<T> FindAsync(Expression<Func<T,bool>> criteria, string[] includes = null)
		{
			IQueryable<T> query = _context.Set<T>();
			if (includes != null && includes.Length > 0)
			{
				foreach (var include in includes)
				{
					query = query.Include(include);
				}
			}
			try
			{
				return await query.SingleOrDefaultAsync(criteria);
			}
			catch (InvalidOperationException ex)
			{
				// Log the error or handle it accordingly
				throw new Exception("More than one entity found matching the criteria", ex);
			}
			catch (Exception ex)
			{
				// Handle other possible exceptions
				throw new Exception("An error occurred while retrieving the entity", ex);
			}
		}

		public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
		{
			IQueryable<T> query = _context.Set<T>();
			if (includes != null && includes.Length > 0)
			{
				foreach (var include in includes)
				{
					query = query.Include(include);
				}
			}
			try
			{
				return await query.Where(criteria).ToListAsync();
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int take, int skip)
		{
			return await _context.Set<T>().Where(criteria).Skip(skip).Take(take).ToListAsync();
		}
		public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? take, int? skip,
			Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending)
		{
			IQueryable<T> query = _context.Set<T>().Where(criteria);
			if (take.HasValue)
			{
				query = query.Take(take.Value);
			}
			if (skip.HasValue)
			{
				query = query.Skip(skip.Value);
			}
			if (orderBy != null)
			{
				if (orderByDirection == OrderBy.Ascending)
				{
					query = query.OrderBy(orderBy);
				}
				else
				{
					query = query.OrderByDescending(orderBy);
				}
			}
			return await query.ToListAsync();
		}

		public async Task<T> AddOneAsync(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
			return entity;
		}

		public async Task<IEnumerable<T>> AddListAsync(IEnumerable<T> entities)
		{
			await _context.Set<T>().AddRangeAsync(entities);
			return entities;
		}
		//public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
		//{
		//	await _context.Set<T>().AddRangeAsync(entities);
		//	return entities;
		//}

		//public T Update(T entity)
		//{
		//	_context.Update(entity);
		//	return entity;
		//}

		//public void Delete(T entity)
		//{
		//	_context.Set<T>().Remove(entity);
		//}

		//public void DeleteRange(IEnumerable<T> entities)
		//{
		//	_context.Set<T>().RemoveRange(entities);
		//}

		public async Task<T> UpdateOneAsync(T entity)
		{
			_context.Set<T>().Update(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<IEnumerable<T>> UpdateListAsync(IEnumerable<T> entities)
		{
			_context.Set<T>().UpdateRange(entities);
			await _context.SaveChangesAsync();
			return entities;
		}

		public async Task<T> DeleteOneAsync(T entity)
		{
			_context.Set<T>().Remove(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<IEnumerable<T>> DeleteListAsync(IEnumerable<T> entities)
		{
			_context.Set<T>().RemoveRange(entities);
			await _context.SaveChangesAsync();
			return entities;
		}

		public void Attach(T entity)
		{
			_context.Set<T>().Attach(entity);
		}
		public void AttachRange(IEnumerable<T> entities)
		{
			_context.Set<T>().AttachRange(entities);
		}

		public async Task<int> CountAsync()
		{
			return await _context.Set<T>().CountAsync();
		}

		public async Task<int> CountAsync(Expression<Func<T, bool>> criteria)
		{
			return await _context.Set<T>().CountAsync(criteria);
		}
	}
}
