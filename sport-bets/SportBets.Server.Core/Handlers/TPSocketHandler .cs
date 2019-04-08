using SportBets.Core.Serializer;
using SportBets.Server.Core.Networking;
using SportBets.Server.Core.RequestHandler;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SportBets.Server.Core.Handlers
{
	public class TPSocketHandler : ISocketHandler
	{
		private IRequestHandler _requestHandler;

		public TPSocketHandler(IRequestHandler requestHandler)
		{
			_requestHandler = requestHandler;
		}

		public async Task Process(Socket socket)
		{
			//TODO: dependency -> json fix.
			await Task.Run(async () =>
			{
				var tp = new TransferProtocol(socket, new JsonSerializer());
				var request = tp.Receive<TPRequest>();
				await _requestHandler.Handle(request, tp);
			});
		}
	}
}