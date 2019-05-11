using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using SportBets.Server.Services.Contracts;
using SportBets.Server.Database.Entities;
using SportBets.Server.Database.Interfaces;

namespace SportBets.Server.Services
{
	public abstract class AbstractServrice<T> : ISerivceBase<T> 
		where T : BaseEntity
	{
		protected readonly IUnitOfWork _database;
		private bool _disposed;

		public AbstractServrice(IUnitOfWork database)
		{
			_database = database;
		}

		public abstract IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, bool lazeLoad = true);
		public abstract bool Add(T t);
		public abstract void Edit(T t);
		public abstract void Delete(int id);

		protected virtual void Dispose(bool dispose)
		{
			if (!_disposed)
			{
				if (dispose)
				{
					_database.Save();
					_disposed = true;
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true);
		}
	}
}
