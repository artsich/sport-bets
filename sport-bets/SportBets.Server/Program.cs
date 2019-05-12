#define LOCAL_TEST
using SportBets.Core.Serializer;
using SportBets.Server.Core.Handlers;
using SportBets.Server.Core.Networking;
using SportBets.Server.Core.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SportBets.Server.Handlers;
using SportBets.Core.Networking;
using System.Reflection;
using SportBets.Server.Core;
using SportBets.Server.Controllers;

namespace SportBets.Server
{
	class Program
	{
		const int ServerPort = 5555;

		public static async Task Main(string[] args)
		{
#if !SERVISES_TEST
		
#endif
			var requestHandler = new RequestHandler();
			var socketHanler = new TPSocketHandler(requestHandler, new JsonSerializer());
			var server = new Server(socketHanler, ServerPort);
			server.Log = (x) => Console.WriteLine(x);
			server.Run();

#if !LOCAL_TEST
			var client = TestClient();
			var req = TestGetRequest();
			var resp = await client.Get(req);
			Console.WriteLine($"Client recieve: {resp.JsonData}");
#endif
			Thread.Sleep(10000000);
		}

		private static TPRequest TestGetRequest()
		{
			var header = new Header()
			{
				Address = "127.0.0.1",
				Port = ServerPort,
				AddressFamily = AddressFamily.InterNetwork
			};

			var request = new TPRequest()
			{
				Header = header,
				Uri = "user/signin",
				Args = new Arg[]
				{
					TPRequest.BuildArg("login", "q222"),
					TPRequest.BuildArg("password", "1111")
				}
			};

			return request;
		}

		private static TransferProtocolClient TestClient()
		{
			return new TransferProtocolClient(new JsonSerializer());
		}
		
	}
}
