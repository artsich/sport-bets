using SportBets.Server.Database;
using SportBets.Server.Database.Entities;
using SportBets.Server.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SportBets.Server.Services
{
	public class UserService : AbstractServrice<User>
	{
		private IGenericRepository<User> _userRepository;

		public UserService(IUnitOfWork _database) : base(_database)
		{
			_userRepository = _database.GetRepository<User>();
		}

		public override bool Add(User user)
		{
			bool result = false;
			TryValidateModel(user);

			int existUsers = _userRepository
				.Get((x) => x.Login == user.Login)
				.Count();

			if (existUsers == 0)
			{
				user.DateRegistration = DateTime.Now;
				_userRepository.Insert(user);
				result = true;
			}

			return result;
		}

		public override void Delete(int id)
		{
			if(id < 0)
			{
				throw new ArgumentOutOfRangeException($"{nameof(id)} < 0");
			}
			_userRepository.Delete(id);
		}

		public override void Edit(User t)
		{
			TryValidateModel(t);
			_userRepository.Update(t);
		}

		public override IEnumerable<User> Get(Expression<Func<User, bool>> filter = null, bool lazeLoad = true)
		{
			if(lazeLoad)
			{
				return _userRepository.Get(filter, "");
			}

			return _userRepository.Get(filter);
		}

		private void TryValidateModel(User client)
		{
			if (string.IsNullOrEmpty(client.Name))
			{
				throw new ArgumentNullException("User name empty or null");
			}

			if (client.Name.Length < 0 && client.Name.Length > 100)
			{
				throw new ArgumentOutOfRangeException("User name length out of range");
			}
		}
	}
}
