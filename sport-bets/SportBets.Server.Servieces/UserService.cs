using SportBets.Server.Database;
using SportBets.Server.Database.Entities;
using SportBets.Server.Database.Interfaces;
using SportBets.Server.Servieces.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SportBets.Server.Services
{
	public class UserService : AbstractServrice<User>, IUserService
	{
		private IGenericRepository<User> _userRepository;

		public UserService() : this(new BetsUnitOfWork())
		{
		}

		public UserService(IUnitOfWork _database) : base(_database)
		{
			_userRepository = _database.GetRepository<User>();
		}

		public async override Task<User> Add(User user)
		{
			TryValidateModel(user);

			int existUsers = _userRepository
				.Get((x) => x.Login == user.Login)
				.Count();

			if (existUsers == 0)
			{
				user.DateRegistration = DateTime.Now;
				_userRepository.Insert(user);
			}
			await _database.Save();
			return user;
		}

		public override void Delete(int id)
		{
			if (id < 0)
			{
				throw new ArgumentOutOfRangeException($"{nameof(id)} < 0");
			}
			_userRepository.Delete(id);
		}

		public override async Task<User> Edit(User user)
		{
			TryValidateModel(user);
			_userRepository.Update(user);
			await _database.Save();
			return user;
		}

		public override IEnumerable<User> Get(Expression<Func<User, bool>> filter = null, bool lazeLoad = true)
		{
			if (lazeLoad)
			{
				return _userRepository.Get(filter, "");
			}

			return _userRepository.Get(filter);
		}

		public User GetUserByLoginPass(string login, string password)
		{
			return Get(x => x.Login.Equals(login) && x.Password.Equals(password)).FirstOrDefault();
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
