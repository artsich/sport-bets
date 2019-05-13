using System;
using System.Threading.Tasks;
using SportBets.Core.Networking;
using SportBets.Server.Core.Networking;
using SportBets.Server.Handlers;
using SportBets.Server.Services;

namespace SportBets.Server.Core.Handlers
{
	public class RequestHandler : IRequestHandler, ILog
	{
		public Action<String> Log { get; set; }

		public async Task Handle(TPRequest request, TransferProtocolServer protocol)
		{
			await Task.Run(() =>
			{
				PrintLog(request);
				var controller = new ControllerHandler();
				var reqContext = new RequestContext(request);	
				
				controller.Execute(reqContext);
				protocol.Send(reqContext.Responce);
			});
		}

		private void PrintLog(TPRequest req)
		{
			string args = "";

			for (int i = 0; i < req.Args.Length; ++i)
			{
				args += req.Args[i] + " : ";
			}

			Log?.Invoke($"\turi: {req.Uri}, \n\t args: {args}");
		}

	}
}