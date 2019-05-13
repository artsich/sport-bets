using SportBets.Services.Interfaces;
using SportBets.Services.Models;
using SportBets.Win10.Bihevior;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportBets.Win10.ViewModels
{
	public class HomeViewModel : BaseViewModel
	{
		private IEventService _eventService;
		private AuthUserManager _authManager;
		private IEnumerable<EventInfo> _events;
		private string _errorMessage;

		public string ErrorMessage
		{
			get => _errorMessage;
			set
			{
				_errorMessage = value;
				OnPropertyNotified(nameof(ErrorMessage));
			}
		}

		public IEnumerable<EventInfo> Events
		{
			get => _events;
			set
			{
				_events = value;
				OnPropertyNotified(nameof(Events));
			}
		}

		public HomeViewModel(IEventService eventService, AuthUserManager authManager)
		{
			_eventService = eventService;
			_authManager = authManager;
		}

		public async Task Load()
		{
			Events = await _eventService.Get();
		}

		public void ShowDialogMoreEventInfo(EventInfo eventInfo)
		{
			//TODO: Some code...
		}
	}
}