using SportBets.Core.Contracts;
using SportBets.Core.Servises;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportBets.Core.ViewModels
{
	public class SignInViewModel : BaseViewModel
	{
		private INagvigationManager _nagvigationManager;

		private string _login;
		private string _password;

		public string Login
		{
			get => _login;
			set
			{
				_login = value;
				OnPropertyNotified(nameof(Login));
			}
		}

		public string Password
		{
			get => _password;
			set
			{
				_password = value;
				OnPropertyNotified(nameof(Password));
			}
		}

		public SignInViewModel(INagvigationManager nagvigationManager,
			IUserService _userManager)
		{
			_nagvigationManager = nagvigationManager;

		}

		public void SignIn()
		{
			if(!string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password))
			{

				_nagvigationManager.NovigateTo(Page.SignUp);
			}
		}

		public void SignUp()
		{
			_nagvigationManager.NovigateTo(Page.SignUp);
		}
	}
}
