using SportBets.Server.Database.Entities;
using SportBets.Server.Services.Contracts;

namespace SportBets.Server.Servieces.Contracts
{
	public interface IUserService : ISerivceBase<User>
	{
		User GetUserByLoginPass(string login, string password);
	}
}
