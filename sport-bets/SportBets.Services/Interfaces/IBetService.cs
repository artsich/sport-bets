using SportBets.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportBets.Services.Interfaces
{
	public interface IBetService
	{
		Task Create(CreatedInfoBet bet);
		Task Update(Bet bet);
		Task Delete(int id);
		Task<IEnumerable<Bet>> Get();
		Task<Bet> GetById(int id);
		Task<bool> MakeBet(int userId, int betResultId, int summa);
	}
}
