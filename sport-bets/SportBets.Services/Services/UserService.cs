using SportBets.Core;
using SportBets.Core.WebApi;
using SportBets.Services.Interfaces;
using SportBets.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportBets.Services
{
	public class UserService : IUserService
	{
		private readonly IWebApi _webApi;

		public UserService(IWebApi webApi)
		{
			_webApi = webApi;
		}

		public async Task<RegistratedUser> SignUp(RegisterInfoUser user)
		{
			var args = new ArgsBuilder()
				.Add(nameof(user.Login), user.Login)
				.Add(nameof(user.Password), user.Login)
				.Add(nameof(user.Name), user.Login)
				.Add(nameof(user.Age), user.Age.ToString())
				.Add(nameof(user.Score), user.Age.ToString())
				.Build();

			var result = await _webApi.Query<RegistratedUser>(Defines.UserServices.SignUpUserUrl, args);
			return result.Responce;
		}

		public async Task<RegistratedUser> GetById(int Id)
		{
			var args = new ArgsBuilder()
				.Add(nameof(Id), Id.ToString())
				.Build();

			var result = await _webApi.Query<RegistratedUser>(Defines.UserServices.GetUserByIdUrl, args);
			return result.Responce;
		}

		public async Task<IEnumerable<RegistratedUser>> Get()
		{
			var result = await _webApi.Query<IEnumerable<RegistratedUser>>(Defines.UserServices.GetAllUsers);
			return result.Responce;
		}

		public async Task<RegistratedUser> SignIn(string login, string password)
		{
			var args = new ArgsBuilder()
				.Add(nameof(login), login)
				.Add(nameof(password), password)
				.Build();

			var result = await _webApi.Query<RegistratedUser>(Defines.UserServices.SignInUserUrl, args);
			return result.Responce;
		}
	}
}