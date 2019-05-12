using System;
using System.Threading.Tasks;
using SportBets.Core.Networking;
using SportBets.Server.Core.Networking;
using SportBets.Server.Handlers;
using SportBets.Server.Services;

namespace SportBets.Server.Core.Handlers
{
	public class RequestHandler : IRequestHandler
	{
		public async Task Handle(TPRequest request, TransferProtocolServer protocol)
		{
			await Task.Run(() =>
			{
				var controller = new ControllerHandler();
				var reqContext = new RequestContext(request);	
				
				controller.Execute(reqContext);
				protocol.Send(reqContext.Responce);
			});
		}
	}
}