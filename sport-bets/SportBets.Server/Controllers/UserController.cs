using System;
using System.Linq;
using System.Text;
using SportBets.Server.Core;
using System.Threading.Tasks;
using SportBets.Server.Services;
using SportBets.Server.Database;
using System.Collections.Generic;
using SportBets.Server.Database.Entities;

namespace SportBets.Server.Controllers
{
	public class UserController : IControllerMarker
	{
		public object SignIn(string login, string password)
		{
			using (var service = new UserService())
			{
				return Map(service.GetUserByLoginPass(login, password));
			}
		}

		public async Task<object> SignUp(string login, string password, string name, string age)
		{
			using (var service = new UserService())
			{
				int.TryParse(age, out int resultAge);

				return Map(await service.Add(new User()
				{
					Login = login,
					Password = password,
					Name = name,
					Age = resultAge,
					Score = 0
				}));
			}
		}

		public object GetById(string stringId)
		{
			int.TryParse(stringId, out int Id);

			using (var service = new UserService())
			{
				return service.Get(x => x.Id == Id).Select(x => Map(x)).FirstOrDefault();
			}
		}

		public IEnumerable<object> GetAll()
		{
			using (var service = new UserService())
			{
				return service.Get().Select(x => Map(x));
			}
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
	}
}