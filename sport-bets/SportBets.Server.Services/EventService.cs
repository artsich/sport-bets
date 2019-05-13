using System;
using System.Linq;
using System.Threading.Tasks;
using SportBets.Server.Database;
using SportBets.Server.Database.Entities;
using SportBets.Server.Database.Interfaces;
using SportBets.Server.Services.Contracts;

namespace SportBets.Server.Services
{
	public class EventService : BaseService<Event>, IEventService
	{
		public EventService() : this(new BetsUnitOfWork())
		{
		}

		public EventService(IUnitOfWork _database) : base(_database)
		{
			IncludeString = "TypeSport";
		}

		public async override Task<Event> Add(Event sportEvent)
		{
			TryValidateModel(sportEvent);

			int existsEvent = _repository.Get()
				.Where(x => x.Name == sportEvent.Name)
				.Where(x => x.DataTime == sportEvent.DataTime)
				.Count();

			if (existsEvent == 0)
			{
				_repository.Insert(sportEvent);
				await _database.Save();
			}

			return sportEvent;
		}

		protected override void TryValidateModel(Event sportEvent)
		{
			if (sportEvent == null)
			{
				throw new ArgumentNullException();
			}

			if (string.IsNullOrEmpty(sportEvent.Name))
			{
				throw new ArgumentNullException("Event name empty or null");
			}

			if (sportEvent.Teams.Count < 1)
			{
				throw new ArgumentNullException("Can't be teams less 1");
			}

			if (sportEvent.DataTime < DateTime.Now)
			{
				throw new ArgumentOutOfRangeException("DateTime less NOW");
			}
		}
	}
}