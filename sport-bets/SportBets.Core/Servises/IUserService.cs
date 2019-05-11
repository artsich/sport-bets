using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using SportBets.Server.Database.Entities;

namespace SportBets.Core.Servises
{
	public interface IUserService
	{
		Task AddUser(User user);
		Task<User> Get(Expression<Func<User, bool>> filter);
		Task<IEnumerable<User>> Get();
	}
}