using SportBets.Core;
using SportBets.Core.Contracts;
using SportBets.Win10.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace SportBets.Win10.Bihevior
{
	class NavigationManager : INagvigationManager
	{
		private Frame _contentFrame;

		public NavigationManager(Frame contentFrame)
		{
			_contentFrame = contentFrame;
		}

		public void NovigateTo(string page)
		{
			switch(page)
			{
				//case Core.Page.HistoryPage.ToString():
				//	_contentFrame.Navigate(typeof(HistoryView));
				//	break;
				//case Core.Page.HomePage.ToString():
				//	_contentFrame.Navigate(typeof(HomeView));
				//	break;

			}
		}
	}
}
