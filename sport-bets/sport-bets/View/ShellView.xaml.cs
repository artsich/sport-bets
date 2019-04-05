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
	public sealed partial class ShellView : Page
	{
		private ShellViewModel ViewModel { get; }

		public ShellView()
		{
			this.InitializeComponent();
			DataContext = Dependencies.ShellViewModel;
		}

		private void ListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var selectedItem = (ListBoxItem)((ListBox)sender)?.SelectedItem;
			var page = selectedItem?.Name;
			ViewModel.NavigateTo(page);
		}

		private void HamburgerButtonClick(object sender, RoutedEventArgs e)
		{
			SplitPanel.IsPaneOpen = !SplitPanel.IsPaneOpen;
		}
	}
}
