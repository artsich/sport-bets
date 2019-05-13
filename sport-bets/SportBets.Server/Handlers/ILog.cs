using System;

namespace SportBets.Server.Handlers
{
	internal interface ILog
	{
		Action<string> Log { get; set; }
	}
}
