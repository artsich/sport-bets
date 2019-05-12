using System;
using System.Threading.Tasks;
using SportBets.Server.Database.Entities;
using SportBets.Server.Database.Interfaces;

namespace SportBets.Server.Database
{
	public class BetsUnitOfWork : IUnitOfWork
	{
		private BetsDbContext _context = new BetsDbContext();
		private bool _disposed = false;

		public IGenericRepository<Entity> GetRepository<Entity>() where Entity : class
		{
			return new BetsRepository<Entity>(_context);
		}

		public async Task Save()
		{
			await _context.SaveChangesAsync();
		}

		private void Dispose(bool dispose)
		{
			if (!_disposed)
			{
				if (dispose)
				{
					_context.Dispose();
					_disposed = false;
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
