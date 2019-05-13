using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportBets.Server.Core;
using SportBets.Server.Database.Entities;
using SportBets.Server.Services;
using SportBets.Server.Services.Contracts;

namespace SportBets.Server.Controllers
{
	public class BetController : IControllerMarker
	{
		private IBetService _service = new BetService();

		public async Task<object> MakeBet(int userId, int betResultId, int summa)
		{
			var result = await _service.MakeBet(userId, betResultId, summa);
			return new { Result = result };				
		}

		public object GetById(int id)
		{
			return Map(_service.Get(x => x.Id == id).FirstOrDefault());
		}

		public IEnumerable<object> Get()
		{
			return _service.Get().ToList().Select(x => Map(x));
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

		public void Dispose()
		{
			_service.Dispose();
		}
	}
}