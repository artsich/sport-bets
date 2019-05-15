using SportBets.Server.Database.Interfaces;
using SportBets.Server.Services.Contracts;

namespace SportBets.Server.Services
{
	public interface IServiveFactory
	{
		IUserService GetUserService(IUnitOfWork unitOfWork);
		IBetService GetBetService(IUnitOfWork unitOfWork);
		IEventService GetEventService(IUnitOfWork unitOfWork);
	}
}