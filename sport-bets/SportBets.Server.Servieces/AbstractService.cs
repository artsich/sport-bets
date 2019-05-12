using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using SportBets.Server.Services.Contracts;
using SportBets.Server.Database.Entities;
using SportBets.Server.Database.Interfaces;
using System.Threading.Tasks;

namespace SportBets.Server.Services
{
	public abstract class BaseService<T> : ISerivceBase<T> 
		where T : BaseEntity
	{
		protected readonly IUnitOfWork _database;
		protected IGenericRepository<T> _repository;

		private bool _disposed;

		public BaseService(IUnitOfWork database)
		{
			_database = database;
			_repository = _database.GetRepository<T>();
		}

		public abstract Task<T> Add(T model);
		protected abstract void TryValidateModel(T model);

		public virtual async Task Delete(int id)
		{
			if (id < 0)
			{
				throw new ArgumentOutOfRangeException($"{nameof(id)} < 0");
			}
			await _repository.Delete(id);
			await _database.Save();
		}

		public virtual async Task<T> Edit(T model)
		{
			TryValidateModel(model);
			_repository.Update(model);
			await _database.Save();
			return model;
		}

		public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, bool lazeLoad = true)
		{
			if (lazeLoad)
			{
				return _repository.Get(filter, "");
			}
			return _repository.Get(filter);

		}

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
