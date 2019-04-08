using SportBets.Core.Contracts;
using SportBets.Core.ViewModel;
using System.Collections.Generic;

namespace SportBets.Win10.ViewModels
{
	public class ShellViewModel : BaseViewModel
	{
		private INagvigationManager _nagvigationManager;
		private IList<ShellItemViewModel> _items;

		public IList<ShellItemViewModel> ShellItems
		{
			get => _items;
			set
			{
				_items = value;
				OnPropertyNotified(nameof(ShellItems));
			}
		}

		public ShellViewModel(INagvigationManager nagvigationManager)
		{
			_nagvigationManager = nagvigationManager;
			ShellItems = new List<ShellItemViewModel>()
			{
				new ShellItemViewModel(){ Image = "&#xE80F;", PageName="Home"},
				new ShellItemViewModel(){ Image = "&#xE81C;", PageName="History"}
			};
		}

		public void NavigateTo(string namePage)
		{
			_nagvigationManager.NovigateTo(namePage);
		}
	}
}