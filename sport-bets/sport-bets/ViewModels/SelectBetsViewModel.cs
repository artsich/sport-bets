using System.Threading.Tasks;
using System.Collections.Generic;
using SportBets.Win10.Bihevior;
using SportBets.Services.Models;
using SportBets.Services.Interfaces;

namespace SportBets.Win10.ViewModels
{
	public class SelectBetsViewModel : BaseViewModel
	{
		private string _errorMessage;

		private IBetService _betService;
		private IEventService _eventService;
		private IEnumerable<EventInfo> _events;
		private AuthUserManager _authUserManager;

		public IEnumerable<EventInfo> Events
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

		public SelectBetsViewModel(IBetService betService, 
			IEventService eventService,
			AuthUserManager authUserManager)
		{
			_eventService = eventService;
			_betService = betService;
			_authUserManager = authUserManager;
		}

		public async Task MakeBet(int resultId, int summa)
		{
			if(summa <= 0 || resultId < 0)
			{
				return;
			}
			if(_authUserManager.IsAuthorize)
			{
				var result = await _betService.MakeBet(_authUserManager.User.Id, resultId, summa);
				if(!result.Result)
				{
					ErrorMessage = "Oops something went wrong";
				}
			}
		}
		
		public async Task Load()
		{
			Events = await _eventService.Get();

			if(Events == null)
			{
				ErrorMessage = "Can't load events";
			}
		}
	}
}
