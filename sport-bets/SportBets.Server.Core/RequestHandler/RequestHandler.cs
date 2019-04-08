using System.Threading.Tasks;
using SportBets.Server.Core.Networking;

namespace SportBets.Server.Core.RequestHandler
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
		public async Task Handle(TPRequest request, TransferProtocol protocol)
		{
			await Task.Run(() => 
			{
				System.Console.WriteLine($"Request processing: {request.Uri}");

				var resp = new TPResponse()
				{
					JsonData = $"Hello {request.SenderAddr.IPEnd.Address}:{request.SenderAddr.IPEnd.Port} ," +
								$"From: {request.RemoteAddr.IPEnd.Address}:{request.RemoteAddr.IPEnd.Port}",
					Status = StatusCode.OK
				};

				protocol.Send(resp);
			});
		}

		private void ArgsParser(Arg[] args)
		{
			if(args == null)
			{
				throw new System.ArgumentNullException(nameof(args));
			}



		}
	}
}