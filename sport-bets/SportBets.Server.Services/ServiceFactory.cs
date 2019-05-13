using SportBets.Server.Database.Interfaces;
using SportBets.Server.Services.Contracts;

namespace SportBets.Server.Services
{
	public class ServiceFactory : IServiveFactory
	{
		public IBetService GetBetService(IUnitOfWork unitOfWork)
		{
			return new BetService(unitOfWork);
		}

		public IEventService GetEventService(IUnitOfWork unitOfWork)
		{
			return new EventService(unitOfWork);
		}

		public IUserService GetUserService(IUnitOfWork unitOfWork)
		{
			return new UserService(unitOfWork);
		}
	}
}