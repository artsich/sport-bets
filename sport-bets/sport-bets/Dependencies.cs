using SportBets.Core.Contracts;
using SportBets.Win10.ViewModels;

namespace SportBets.Win10
{
	public static class Dependencies
	{
		public static INagvigationManager NagvigationManager;
		public static ShellViewModel ShellViewModel = new ShellViewModel(NagvigationManager);
	}
}