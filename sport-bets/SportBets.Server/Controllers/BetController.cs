using SportBets.Server.Core;
using SportBets.Server.Database.Entities;
using SportBets.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportBets.Server.Controllers
{
	public class BetController : IControllerMarker
	{
		public object GetById(int id)
		{
			using (var service = new BetService())
			{
				return Map(service.Get(x => x.Id == id).FirstOrDefault());
			}
		}

		public IEnumerable<object> Get()
		{
			using (var service = new BetService())
			{
				return service.Get().ToList().Select(x => Map(x));
			}
		}

		private object Map(Bet bet)
		{
			if (bet == null)
			{
				return null;
			}
			var eventObj = new
			{
				bet.Event.Id,
				bet.Event.Name,
				bet.Event.Teams,
				bet.Event.TypeSport
			};

			return new
			{
				Id = bet.Id,
				Name = bet.Name,
				Event = eventObj,
				Results = bet.Results.Select(x => new
				{
					x.Id,
					x.Description,
					x.Coefficient
				}),
			};
		}
	}
}