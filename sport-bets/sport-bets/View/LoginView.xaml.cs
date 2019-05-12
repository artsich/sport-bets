using SportBets.Win10.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SportBets.Win10.View
{
	public sealed partial class LoginView : Page
	{
		private SignInViewModel ViewModel { get; }

		public LoginView()
		{
			InitializeComponent();
			ViewModel = DataContext as SignInViewModel;
		}

		private async void OnSignUpButtonClick(object sender, RoutedEventArgs e)
		{
			await ViewModel.SignUp();
		}

		private async void OnSignInButtonClick(object sender, RoutedEventArgs e)
		{
			await ViewModel.SignIn();
		}
	}
}
