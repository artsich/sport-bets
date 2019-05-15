using SportBets.Services.Models;
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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SportBets.Win10.CustomControls
{
	public sealed partial class SelectBetResultDialog : ContentDialog
	{
		public ICollection<BetResult> BetResults { get; set; }

		public Action<int, int> MakeBetClick;
		public Action CancelKeyClick;

		public SelectBetResultDialog()
		{
			this.InitializeComponent();
		}

		private void OnPrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
		{
			if (BetResultsList.SelectedItem != null)
			{
				int.TryParse(Summa.Text, out var result);
				var resultId = (BetResultsList.SelectedItem as BetResult)?.Id;
				if(resultId != null)
				{
					MakeBetClick?.Invoke(resultId.Value, result);
				}
			}
		}

		private void OnSecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
		{
			CancelKeyClick?.Invoke();
		}
	}
}
