using System.Threading.Tasks;
using SportBets.Server.Database.Entities;
using SportBets.Server.Services.Models;

namespace SportBets.Server.Services.Contracts
{
	public interface IBetService : ISerivceBase<Bet>
	{
		Task<bool> MakeBet(int userId, int betResultId, int summa);
		void SpecifyResultForBet(BetResultInfo info);
	}
}
