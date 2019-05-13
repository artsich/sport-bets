using SportBets.Services.Models;
using SportBets.Win10.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace SportBets.Win10.View
{
	public sealed partial class HomeView : Page
	{
		private HomeViewModel ViewModel { get; }
		public HomeView()
		{
			this.InitializeComponent();
			ViewModel = DataContext as HomeViewModel;
		}

		private void OnEventClick(object sender, SelectionChangedEventArgs e)
		{
			ViewModel.ShowDialogMoreEventInfo(Events.SelectedItem as EventInfo);
		}

		private async void OnLoadedGrid(object sender, RoutedEventArgs e)
		{
			await ViewModel.Load();
		}
	}
}