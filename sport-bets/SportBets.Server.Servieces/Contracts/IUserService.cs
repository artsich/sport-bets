using SportBets.Server.Database.Entities;

namespace SportBets.Server.Services.Contracts
{
	public interface IUserService : ISerivceBase<User>
	{
		User GetUserByLoginPass(string login, string password);
	}
}
