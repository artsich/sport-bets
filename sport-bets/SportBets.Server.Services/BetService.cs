using System;
using System.Linq;
using System.Threading.Tasks;
using SportBets.Server.Database;
using SportBets.Server.Database.Entities;
using SportBets.Server.Database.Interfaces;
using SportBets.Server.Services.Contracts;

namespace SportBets.Server.Services
{
	public class BetService : BaseService<Bet>, IBetService
	{
		public BetService() : this(new BetsUnitOfWork())
		{
		}

		public BetService(IUnitOfWork _database) : base(_database)
		{
			IncludeString = "Event";
		}

		public async Task<bool> MakeBet(int userId, int betResultId, int summa)
		{
			var betsRepos = GetRepository<BetResult>();
			var userRepos = GetRepository<User>();
			var placedBets = GetRepository<PlacedBet>();

			var user = userRepos.Get(x => x.Id == userId && x.Score >= summa).FirstOrDefault();
			if (user == null)
			{
				return false;
			}

			var betResult = betsRepos.Get(x => x.Id == betResultId).FirstOrDefault();
			if(betResult == null)
			{
				return false;
			}

			int checkExistPlace = placedBets
						.Get(x => x.BetId == betResult.BetId && 
							x.UserId == userId).Count();

			if(checkExistPlace > 0)
			{
				return false;
			}

			var newPlacedBet = new PlacedBet()
			{
				BetId = betResult.BetId,
				DataPlaced = DateTime.Now,
				Summa = summa,
				UserId = user.Id,
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
