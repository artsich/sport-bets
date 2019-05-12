using Ninject.Modules;
using SportBets.Core.Networking;
using SportBets.Core.Serializer;
using SportBets.Core.WebApi;
using SportBets.Services;
using SportBets.Services.Interfaces;
using SportBets.Services.Services;
using SportBets.Win10.Bihevior;
using SportBets.Win10.ViewModels;

namespace SportBets.Win10.DIModules
{
	public class SportBetsModule : NinjectModule
	{
		public override void Load()
		{
			Bind<ISerializer>().To<JsonSerializer>();
			Bind<IWebApi>().To<WebApi>()
				.WithConstructorArgument(new Header()
				{
					Address = Defines.ServerIp,
					AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork,
					Port = Defines.ServerPort
				});

			Bind<IBetService>().To<BetService>();
			Bind<IUserService>().To<UserService>();
			Bind<IEventService>().To<EventService>();

			Bind<SignInViewModel>().ToSelf();

			Bind<AuthUserManager>()
				.ToSelf()
				.InSingletonScope();
		}
	}
}