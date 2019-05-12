using System.Threading.Tasks;
using System.Collections.Generic;
using SportBets.Services.Models;

namespace SportBets.Services.Interfaces
{
	public interface IUserService
	{
		Task<RegistratedUser> SignUp(RegisterInfoUser user);
		Task<IEnumerable<RegistratedUser>> Get();
		Task<RegistratedUser> GetById(int id);
		Task<RegistratedUser> SignIn(string login, string pass);
	}
}