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
		public async Task Handle(TPRequest request, TransferProtocolServer protocol)
		{
			await Task.Run(() => 
			{
				System.Console.WriteLine($"Request processing: {request.Uri}");

				var string_data = $"Hello from: {request.Header.Address}, {request.Uri}/";
				foreach(var arg in request.Args)
				{
					string_data += "?";
					string_data += arg.ToString();
				}

				var resp = new TPResponse()
				{
					JsonData = string_data,
					Status = StatusCode.OK
				};

				//TODO: send blocking method
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