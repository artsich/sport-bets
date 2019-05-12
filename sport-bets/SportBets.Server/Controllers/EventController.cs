using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportBets.Server.Services;
using SportBets.Core.Serializer;
using SportBets.Server.Core;
using SportBets.Server.Database.Entities;

namespace SportBets.Server.Controllers
{
	public class EventController : IControllerMarker
	{
		public readonly ISerializer _serializer = new JsonSerializer();

		public async Task<object> Create(string name, string strDateTime, string jsonTeams)
		{
			using (var service = new EventService())
			{
				var teams = _serializer.Deserialize<ICollection<Team>>(jsonTeams);
				DateTime.TryParse(strDateTime, out DateTime dateTime);

				var newEvent = new Event()
				{
					DataTime = dateTime,
					Name = name,
					Teams = teams
				};
				
				return Map(await service.Add(newEvent));
			}
		}

		public async Task<object> Delete(int id)
		{
			using (var service = new EventService())
			{
				try
				{
					await service.Delete(id);
				}
				catch(Exception ex)
				{
					return new { Result = false };
				}
				return new { Result = true };
			}
		}

		public async Task<object> Update(Event targetEvent)
		{
			using (var service = new EventService())
			{
				return Map(await service.Edit(targetEvent));
			}
		}

		public object GetById(int id)
		{
			using (var service = new EventService())
			{
				return Map(service.Get(x => x.Id == id).FirstOrDefault());
			}
		}

		public object Get()
		{
			using (var service = new EventService())
			{
				return service.Get().Select(x => Map(x));
			}
		}

		private object Map(Event ev)
		{
			if(ev == null)
			{
				return ev;
			}

			return new
			{
				ev.Id,
				ev.Name,
				ev.DataTime,
				ev.Teams
			};
		}
	}
}
