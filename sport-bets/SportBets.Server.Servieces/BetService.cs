using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportBets.Server.Database;
using SportBets.Server.Database.Entities;
using SportBets.Server.Database.Interfaces;

namespace SportBets.Server.Services
{
	public class BetService : BaseService<Bet>
	{
		public BetService() : this(new BetsUnitOfWork())
		{
		}

		public BetService(IUnitOfWork _database) : base(_database)
		{
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
