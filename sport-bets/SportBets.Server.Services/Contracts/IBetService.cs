using System.Threading.Tasks;
using SportBets.Server.Database.Entities;

namespace SportBets.Server.Services.Contracts
{
	public interface IBetService : ISerivceBase<Bet>
	{
		Task<bool> MakeBet(int userId, int betResultId, int summa);
	}
}
