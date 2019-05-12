using SportBets.Win10.Bihevior;

namespace SportBets.Win10.ViewModels
{
	public class HomeViewModel : BaseViewModel
	{
		public string UserName { get; set; }
		public string Login { get; set; }
		public string Pass { get; set; }
		public int Score { get; set; }

		public HomeViewModel(AuthUserManager authManager)
		{
		}
	}
}
