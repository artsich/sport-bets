using SportBets.Services.Models;
using System.Threading.Tasks;

namespace SportBets.Services.Interfaces
{
	public interface IBetService
	{
		Task Create(Bet bet);
		Task Update(Bet bet);
		Task Delete(int id);
	}
}
