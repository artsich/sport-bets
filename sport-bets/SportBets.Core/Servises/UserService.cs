using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SportBets.Core.Networking;
using SportBets.Core.WebApi;
using SportBets.Server.Database.Entities;

namespace SportBets.Core.Servises
{
	public class UserService : IUserService
	{
		private IWebApi _webApi;

		public UserService(IWebApi webApi)
		{
			_webApi = webApi;
		}

		public async Task AddUser(User user)
		{
			var args = new ArgsBuilder()
				.Add(nameof(user.Login), user.Login)
				.Add(nameof(user.Password), user.Login)
				.Add(nameof(user.Name), user.Login)
				.Add(nameof(user.Age), user.Age.ToString())
				.Add(nameof(user.Score), user.Age.ToString())
				.Build();

			//var result = await _webApi.GetFrom(Defines.SignUpUserUrl, args);
		}



		public async Task<User> Get(Expression<Func<User, bool>> filter)
		{
		}

		public async Task<IEnumerable<User>> Get()
		{
		}
	}
}
