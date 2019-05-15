using SportBets.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SportBets.Win10.CustomControls
{
	public sealed partial class SelectBetView : UserControl
	{
		public DependencyProperty BetsProperty = DependencyProperty.Register(
			nameof(Bets),
			typeof(ICollection<Bet>),
			typeof(SelectBetView),
			new PropertyMetadata(default(ICollection<Bet>)));

		public DependencyProperty NameEventProperty = DependencyProperty.Register(
			nameof(NameEvent),
			typeof(string),
			typeof(SelectBetView),
			new PropertyMetadata(default(string)));

		public DependencyProperty VisibleBetResultProperty = DependencyProperty.Register(
			nameof(VisibleBetResult),
			typeof(Visibility),
			typeof(SelectBetView),
			new PropertyMetadata(Visibility.Collapsed));

		public DependencyProperty ClickActionProperty = DependencyProperty.Register(
			nameof(ClickAction),
			typeof(Action<int, int>),
			typeof(SelectBetView),
			new PropertyMetadata(default(Action)));

		public Action<int, int> ClickAction
		{
			get => (Action<int, int>)GetValue(ClickActionProperty);
			set => SetValue(ClickActionProperty, value);
		}

		public ICollection<Bet> Bets
		{
			get => (ICollection<Bet>)GetValue(BetsProperty);
			set => SetValue(BetsProperty, value);
		}

		public string NameEvent
		{
			get => (string)GetValue(NameEventProperty);
			set => SetValue(NameEventProperty, value);
		}

		public Visibility VisibleBetResult
		{
			get => (Visibility)GetValue(VisibleBetResultProperty);
			set => SetValue(VisibleBetResultProperty, value);
		}

		public SelectBetView()
		{
			this.InitializeComponent();
		}

		private void OnButtonClick(object sender, RoutedEventArgs e)
		{
			BetResultsList.Visibility = BetResultsList.Visibility == Visibility.Collapsed 
				? Visibility.Visible : Visibility.Collapsed;
			if(BetResultsList.ItemsSource == null)
			{
				BetResultsList.ItemsSource = Bets;
				NameEventText.Text = NameEvent;
			}
		}

		private async void MakeBet(int resultId, int summa)
		{
			await new ViewModels.ViewModelLocator().HomeViewModel.MakeBet(resultId, summa);
		}

		private async void OnBetResultClick(object sender, SelectionChangedEventArgs e)
		{
			var list = Bets.ToList();

			var dialog = new SelectBetResultDialog()
			{
				Title = NameEvent,
				PrimaryButtonText = "Ok",
				SecondaryButtonText = "Cancel",
				BetResults = list[BetResultsList.SelectedIndex].Results,
				MakeBetClick = (id, summa) => MakeBet(id, summa)
			};

			await dialog.ShowAsync();
		}
	}
}