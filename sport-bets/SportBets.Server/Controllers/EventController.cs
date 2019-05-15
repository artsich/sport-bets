using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportBets.Server.Services;
using SportBets.Core.Serializer;
using SportBets.Server.Core;
using SportBets.Server.Database.Entities;
using SportBets.Server.Services.Contracts;

namespace SportBets.Server.Controllers
{
	public class EventController : IControllerMarker
	{
		private readonly ISerializer _serializer = new JsonSerializer();
		private IEventService _service = new EventService();
		private IBetService _betService = new BetService();

		public async Task<object> Create(string name, string strDateTime, string jsonTeams)
		{
			var teams = _serializer.Deserialize<ICollection<Team>>(jsonTeams);
			DateTime.TryParse(strDateTime, out DateTime dateTime);

			var newEvent = new Event()
			{
				DataTime = dateTime,
				Name = name,
				Teams = teams
			};
				
			return Map(await _service.Add(newEvent));
		}

		public async Task<object> Delete(int id)
		{
			try
			{
				await _service.Delete(id);
			}
			catch(Exception ex)
			{
				return new { Result = false };
			}
			return new { Result = true };
		}

		public async Task<object> Update(Event targetEvent)
		{
			return Map(await _service.Edit(targetEvent));
		}

		public object GetById(int id)
		{
			return Map(_service.Get(x => x.Id == id, false).FirstOrDefault());
		}

		public IEnumerable<object> Get()
		{
			return _service.Get().ToList().Select(x => Map(x));
		}

		private object Map(Event ev)
		{
			if(ev == null)
			{
				return ev;
			}
			var betsForEvent = _betService.Get(x => x.EventId == ev.Id, false)
				.ToList()
				.Select(x => new { x.Id, x.Name,
					Results = x.Results.Select(y => new { y.Id, y.Description, y.Coefficient}), x.EventId });

			return new
			{
				ev.Id,
				ev.Name,
				ev.DataTime,
				ev.Teams,
				Bets = betsForEvent
			};
		}

		public void Dispose()
		{
			_service.Dispose();
			_betService.Dispose();
		}
	}
}
