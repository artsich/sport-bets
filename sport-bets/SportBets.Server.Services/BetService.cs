using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportBets.Server.Database;
using SportBets.Server.Database.Entities;
using SportBets.Server.Database.Interfaces;
using SportBets.Server.Services.Contracts;
using SportBets.Server.Services.Models;

namespace SportBets.Server.Services
{
	public class BetService : BaseService<Bet>, IBetService
	{
		private IServiveFactory _serviveFactory;

		public BetService() : this(new ServiceFactory()) {}

		public BetService(IServiveFactory serviceFactory) : this(new BetsUnitOfWork())
		{
			_serviveFactory = serviceFactory;			
		}

		public BetService(IUnitOfWork _database) : base(_database)
		{
			IncludeString = "Event";
		}

		public void SpecifyResultForBet(BetResultInfo info)
		{
			//var betResultsRepos = _repository.GetById(info.BetId);

			//var resultBet = betResultsRepos.GetById(betResultId);
		}

		private bool SpecifyResult(ICollection<BetResult> results, BetResultInfo info)
		{
			var resultsList = results.OrderBy(x => x.Id).ToList();
			var newResults = info.Resutls.OrderBy(x => x.resultId).ToList();
			var userService = _serviveFactory.GetUserService(_database);

			if (newResults.Count != resultsList.Count)
			{
				return false;
			}

			for(int i = 0; i < results.Count; ++i)
			{
				resultsList[i].Result = newResults[i].result;

			}

			return true;
		}

		public async Task<bool> MakeBet(int userId, int betResultId, int summa)
		{
			var betResultsRepos = GetRepository<BetResult>();
			var userService = _serviveFactory.GetUserService(_database);
			var placedBets = GetRepository<PlacedBet>();

			var user = userService.Get(x => x.Id == userId && x.Score >= summa).FirstOrDefault();
			if (user == null && user.Score >= summa && summa > 0)
			{
				return false;
			}

			var betResult = betResultsRepos.Get(x => x.Id == betResultId).FirstOrDefault();
			if(betResult == null)
			{
				return false;
			}

			int checkExistPlace = placedBets
						.Get(x => x.BetResult.BetId == betResult.BetId && 
							x.UserId == userId).Count();

			if(checkExistPlace != 0)
			{
				return false;
			}

			user.Score -= summa;
			await userService.Edit(user);

			var newPlacedBet = new PlacedBet()
			{
				BetResultId = betResult.Id,
				DataPlaced = DateTime.Now,
				Summa = summa,
				UserId = user.Id,
				User = user,
				BetResult = betResult
			};

			placedBets.Insert(newPlacedBet);
			await _database.Save();

			return true;
		}

		public override async Task<Bet> Add(Bet model)
		{
			TryValidateModel(model);

			var targetEvent = _database.GetRepository<Event>().Get()
				.First(x => x.Id == model.EventId);

			if (targetEvent != null)
			{
				int existBets = _repository.Get()
					.Where(x => x.EventId == model.EventId)
					.Where(x => x.Name.ToLower().Equals(model.Name.ToLower()))
					.Count();

				if (existBets == 0)
				{
					_repository.Insert(model);
					await _database.Save();
					return model;
				}
			}
			
			return null;
		}

		protected override void TryValidateModel(Bet model)
		{
			if(model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}

			if (model.Results == null || model?.Results.Count == 0)
			{
				throw new ArgumentNullException(nameof(model));
			}

			//TODO: Other write later
		}
	}
}
