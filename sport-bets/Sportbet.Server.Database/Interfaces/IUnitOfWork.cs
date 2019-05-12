using System;
using System.Threading.Tasks;

namespace SportBets.Server.Database.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IGenericRepository<Entity> GetRepository<Entity>() where Entity : class;
		Task Save();
	}
}
