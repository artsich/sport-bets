using SportBets.Services.Interfaces;
using SportBets.Services.Models;
using SportBets.Win10.Bihevior;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBets.Win10.ViewModels
{
	public class HomeViewModel : BaseViewModel
	{
		private IEventService _eventService;
		private IBetService _betService;
		private ICollection<EventInfo> _events;

		private AuthUserManager _authUserManager;
		private string _errorMessage;

		public ICollection<EventInfo> Events
		{
			get => _events;
			private set
			{
				_events = value;
				OnPropertyNotified(nameof(Events));
			}
		}

		public string ErrorMessage
		{
			get => _errorMessage;
			private set
			{
				_errorMessage = value;
				OnPropertyNotified(nameof(ErrorMessage));
			}
		}

		public HomeViewModel(IEventService eventService, IBetService betService, AuthUserManager authManager)
		{
			_eventService = eventService;
			_betService = betService;
			_authUserManager = authManager;
		}

		public async Task MakeBet(int resultId, int summa)
		{
			if (summa <= 0 || resultId < 0)
			{
				return;
			}

			if (_authUserManager.IsAuthorize)
			{
				var result = await _betService.MakeBet(_authUserManager.User.Id, resultId, summa);
				if (!result.Result)
				{
					ErrorMessage = "Oops something went wrong";
				}
			}
		}

		public async Task Load()
		{
			var result = await _eventService.Get();//await _betService.Get();
			Events = result.ToList();

			if (Events == null)
			{
				ErrorMessage = "Can't load Bets";
			}
		}

	}
}