using SportBets.Core;
using SportBets.Core.WebApi;
using SportBets.Services.Interfaces;
using SportBets.Services.Models;
using System;
using System.Collections.Generic;
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

		public Task Create(CreatedInfoBet bet)
		{
			throw new NotImplementedException();
		}

		public Task Update(Bet bet)
		{
			throw new NotImplementedException();
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Bet>> Get()
		{
			var result = await _webApi.Query<IEnumerable<Bet>>(Defines.BetService.GetBets);
			return result.Responce;
		}

		public async Task<Bet> GetById(int id)
		{
			var args = new ArgsBuilder()
				.Add(nameof(id), id.ToString())
				.Build();

			var result = await _webApi.Query<Bet>(Defines.BetService.GetBetById, args);
			return result.Responce;
		}

		public async Task<bool> MakeBet(int userId, int betResultId, int summa)
		{
			var args = new ArgsBuilder()
				.Add(nameof(userId), userId.ToString())
				.Add(nameof(betResultId), betResultId.ToString())
				.Add(nameof(summa), summa.ToString())
				.Build();

			var result = await _webApi.Query<bool>(Defines.BetService.MakeBet, args);
			return result.Responce;
		}
	}
}