using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SportBets.Server.Database.Entities;

namespace SportBets.Server.Services.Contracts
{
	public interface ISerivceBase<T> : IDisposable 
		where T : BaseEntity
	{
		IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, bool lazeLoad = true);
		bool Add(T t);
		void Edit(T t);
		void Delete(int id);
	}
}
