using SportBets.Win10.Bihevior;
using SportBets.Win10.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SportBets.Win10.View
{
	public sealed partial class ShellView : Page
	{
		private ShellViewModel ViewModel { get; }
		NavigationManager _navigationManager;

		public ShellView()
		{
			this.InitializeComponent();
			ViewModel = DataContext as ShellViewModel;
			_navigationManager = NavigationManager.Instanse;
		}

		private void ListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var selected = (ListBoxItem)Pages.SelectedItem;
			if (Core.Contracts.Page.Home.ToString().Equals(selected.Name))
			{
				_navigationManager.NavigateTo(Core.Contracts.Page.Home);
			}
			else if (Core.Contracts.Page.History.ToString().Equals(selected.Name))
			{
				_navigationManager.NavigateTo(Core.Contracts.Page.History);
			}
		}

		private void HamburgerButtonClick(object sender, RoutedEventArgs e)
		{
			SplitPanel.IsPaneOpen = !SplitPanel.IsPaneOpen;
		}

		private void OnFrameLoad(object sender, RoutedEventArgs e)
		{
			_navigationManager.ContentFrame = ContentFrame;
			_navigationManager.NavigateTo(Core.Contracts.Page.SignIn);
		}
	}
}