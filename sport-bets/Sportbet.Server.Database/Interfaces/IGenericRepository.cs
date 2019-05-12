using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SportBets.Server.Database.Interfaces
{
	public interface IGenericRepository<T>
	{
		IQueryable<T> Get(Expression<Func<T, bool>> filter = null, string includeProperties = "");
		Task<T> GetById(object id);
		void Insert(T item);
		void Update(T item);
		Task Delete(object id);
		void Delete(T item);
	}
}