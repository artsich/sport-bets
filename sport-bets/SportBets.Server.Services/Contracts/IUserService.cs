using SportBets.Server.Database.Entities;
using System.Threading.Tasks;

namespace SportBets.Server.Services.Contracts
{
	public interface IUserService : ISerivceBase<User>
	{
		User GetUserByLoginPass(string login, string password);
		Task TakeOffFromScore(int userId, int amount);
	}
}
