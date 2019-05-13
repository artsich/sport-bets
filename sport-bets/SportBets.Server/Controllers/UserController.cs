using System;
using System.Linq;
using System.Text;
using SportBets.Server.Core;
using System.Threading.Tasks;
using SportBets.Server.Services;
using SportBets.Server.Database;
using System.Collections.Generic;
using SportBets.Server.Database.Entities;
using SportBets.Server.Services.Contracts;

namespace SportBets.Server.Controllers
{
	public class UserController : IControllerMarker
	{
		IUserService _service = new UserService();

		public object SignIn(string login, string password)
		{
			return Map(_service.GetUserByLoginPass(login, password));
		}

		public async Task<object> SignUp(string login, string password, string name, string age)
		{
			int.TryParse(age, out int resultAge);

			return Map(await _service.Add(new User()
			{
				Login = login,
				Password = password,
				Name = name,
				Age = resultAge,
				Score = 0
			}));
		}

		public object GetById(string stringId)
		{
			int.TryParse(stringId, out int Id);
			return _service.Get(x => x.Id == Id).Select(x => Map(x)).FirstOrDefault();
		}

		public IEnumerable<object> GetAll()
		{
			return _service.Get().Select(x => Map(x));
		}

		private object Map(User user)
		{
			if (user == null)
			{
				return null;
			}

			return new
			{
				user.Id,
				user.Name,
				user.Score,
				user.DateRegistration,
				user.Age
			};
		}

		public void Dispose()
		{
			_service.Dispose();
		}
	}
}