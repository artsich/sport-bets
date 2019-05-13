using System;

namespace SportBets.Server.Core
{
	public interface IControllerMarker : IDisposable
	{ }

	public interface IControllerHandler
	{
		void Execute(RequestContext context);
	}
}
