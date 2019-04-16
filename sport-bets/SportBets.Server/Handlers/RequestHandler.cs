using System;
using System.Threading.Tasks;
using SportBets.Server.Core.Networking;
using SportBets.Server.Services;

namespace SportBets.Server.Core.Handlers
{
	/* TODO: parsing requst args ->
	 * select controller ->
	 * select method ->
	 * validate params ->
	 * run method ->
	 * goto service ->
	 * goto database -> 
	 * return result ->
	 */

	public class RequestHandler : IRequestHandler
	{
		private IControllerFactory _serviceHandler;

		public RequestHandler(IControllerFactory serviceHandler)
		{
			_serviceHandler = serviceHandler;
		}

		public async Task Handle(TPRequest request, TransferProtocolServer protocol)
		{
			await Task.Run(() =>
			{
				var controller = _serviceHandler.Process(request.Uri, request.Args);
				var reqContext = new RequestContext(request);

				controller.Execute(reqContext);

				protocol.Send(reqContext.Responce);
			});
		}
	}
}