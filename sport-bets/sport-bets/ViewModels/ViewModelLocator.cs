using Ninject;
using SportBets.Win10.DIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportBets.Win10.ViewModels
{
	public class ViewModelLocator
	{
		private readonly static IKernel _kernel = new StandardKernel(new SportBetsModule());

		public SignInViewModel SignInViewModel
		{
			get => _kernel.Get<SignInViewModel>();
		}
	}
}
