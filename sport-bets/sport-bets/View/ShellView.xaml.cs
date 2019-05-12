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
