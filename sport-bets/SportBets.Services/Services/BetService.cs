using SportBets.Core.WebApi;
using SportBets.Services.Interfaces;
using SportBets.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportBets.Services.Services
{
	public class BetService : IBetService
	{
		private IWebApi _webApi;

		public BetService(IWebApi webApi)
		{
			_webApi = webApi;
		}

		public Task Create(Bet bet)
		{
			throw new NotImplementedException();
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task Update(Bet bet)
		{
			throw new NotImplementedException();
		}
	}
}
