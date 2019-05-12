using System;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using SportBets.Server.Database.Interfaces;
using System.Threading.Tasks;

namespace SportBets.Server.Database
{
	public class BetsRepository<T> : IGenericRepository<T>
		where T : class
	{
		private readonly DbContext _context;
		private readonly DbSet<T> _container;

		public BetsRepository(DbContext context)
		{
			_context = context;
			_container = context.Set<T>();
		}

		public virtual void Insert(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("Item is null!");
			}
			_container.Add(item);
		}

		public virtual async Task Delete(object id)
		{
			if (id == null)
			{
				throw new ArgumentNullException("Item is null!");
			}
			T entity = await GetById(id);
			if (entity != null)
			{
				_container.Remove(entity);
			}
		}

		public virtual void Delete(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("Item is null!");
			}
			if (_context.Entry(item).State == EntityState.Detached)
			{
				_container.Attach(item);
			}
			_container.Remove(item);
		}

		public virtual IQueryable<T> Get(
			Expression<Func<T, bool>> filter = null,
			string includeProperties = "")
		{
			IQueryable<T> query = _container;
			if (filter != null)
			{
				query = query.Where(filter);
			}

			foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, 
				StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			return query;
		}

		public virtual async Task<T> GetById(object id)
		{
			if (id == null)
			{
				throw new ArgumentNullException("Item is null!");
			}

			return await _container.FindAsync(id);
		}

		public virtual void Update(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("Item is null");
			}

			_container.Attach(item);
			_context.Entry(item).State = EntityState.Modified;
		}
	}
}