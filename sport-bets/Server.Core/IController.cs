namespace SportBets.Server.Core
{
	public interface IControllerMarker
	{ }

	public interface IControllerHandler
	{
		void Execute(RequestContext context);
	}
}
