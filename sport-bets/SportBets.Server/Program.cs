using SportBets.Core.Serializer;
using SportBets.Server.Core.Handlers;
using SportBets.Server.Core.Networking;
using SportBets.Server.Core.RequestHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SportBets.Server
{
	class Program
	{
		const int ServerPort = 5555;

		public static async Task Main(string[] args)
		{
			var server = new Server(
				new TPSocketHandler(
					new RequestHandler(), new JsonSerializer()), ServerPort);

			server.Run();

			Console.WriteLine($"Server start on port: {ServerPort}");

			var client = new TransferProtocolClient(new JsonSerializer());
			var remotePoint = new IPEndPoint(IPAddress.Loopback, ServerPort);

			var header = new Header()
			{
				Address = "127.0.0.1",
				Port = ServerPort,
				AddressFamily = AddressFamily.InterNetwork
			};

			var request = new TPRequest()
			{
				Header = header,
				Uri = "users/auth",
				Args = new Arg[]
				{
					TPRequest.BuildArg("pass", "pass11"),
					TPRequest.BuildArg("login", "login@gmail.com")
				}
			};
			
			var resp = await client.Get(request);
			Console.WriteLine(resp.JsonData);

			await Task.Delay(1000000);
		}
	}
}
