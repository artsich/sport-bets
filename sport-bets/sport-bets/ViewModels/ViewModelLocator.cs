using Ninject;
using SportBets.Win10.DIModules;

namespace SportBets.Win10.ViewModels
{
	public class ViewModelLocator
	{
		private readonly static IKernel _kernel = new StandardKernel(new SportBetsModule());

		public SignInViewModel SignInViewModel
		{
			get => _kernel.Get<SignInViewModel>();
		}

		public HomeViewModel HomeViewModel
		{
			get => _kernel.Get<HomeViewModel>();
		}

		public SelectBetsViewModel SelectBetsViewModel
		{
			get => _kernel.Get<SelectBetsViewModel>();
		}
	}
}
