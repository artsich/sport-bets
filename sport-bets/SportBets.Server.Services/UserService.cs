using System;
using System.Linq;
using System.Threading.Tasks;
using SportBets.Server.Database;
using SportBets.Server.Database.Entities;
using SportBets.Server.Database.Interfaces;
using SportBets.Server.Services.Contracts;

namespace SportBets.Server.Services
{
	public class UserService : BaseService<User>, IUserService
	{
		public UserService() : this(new BetsUnitOfWork())
		{}

		public UserService(IUnitOfWork _database) : base(_database)
		{}

		public async override Task<User> Add(User user)
		{
			TryValidateModel(user);

			int existUsers = _repository
				.Get((x) => x.Login == user.Login)
				.Count();

			if (existUsers == 0)
			{
				user.DateRegistration = DateTime.Now;
				_repository.Insert(user);
				await _database.Save();
			}
			return user;
		}

		public User GetUserByLoginPass(string login, string password)
		{
			return Get(x => x.Login.Equals(login) && x.Password.Equals(password)).FirstOrDefault();
		}

		protected override void TryValidateModel(User client)
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
