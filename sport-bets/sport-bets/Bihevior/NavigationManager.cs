using SportBets.Core.Contracts;
using SportBets.Win10.View;
using Windows.UI.Xaml.Controls;
using Page = SportBets.Core.Contracts.Page;

namespace SportBets.Win10.Bihevior
{
	public class NavigationManager : INagvigationManager
	{
		public Frame ContentFrame { get; set; }
		public static NavigationManager Instanse { get; private set; }

		static NavigationManager()
		{
			Instanse = new NavigationManager();
		}

		public void NovigateTo(Frame frame, Page page)
		{
			Frame old = ContentFrame;
			ContentFrame = frame;
			NavigateTo(page);
			ContentFrame = old;
		}

		public void NavigateTo(Page page)
		{
			switch (page)
			{
				case Page.Home:
					ContentFrame.Navigate(typeof(HomeView));
					break;
				case Page.History:
					ContentFrame.Navigate(typeof(HistoryView));
					break;
				case Page.SignIn:
					ContentFrame.Navigate(typeof(LoginView));
					break;
			}
		}
	}
}
