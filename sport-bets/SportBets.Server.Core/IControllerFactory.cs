using SportBets.Core.Networking;

namespace SportBets.Server.Core
{
	public interface IControllerFactory
	{
		//TODO: dependency: TYPE - Arg
		IController Process(string uri, Arg[] args);
	}
}