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

namespace SportBets.Server
{
	class Program
	{
		const int ServerPort = 5555;

		public static async Task Main(string[] args)
		{
			var type = typeof(A);
			var method = type.GetMethod("foo");
			Console.WriteLine(method.Name);

			var @params = method.GetParameters();

			foreach(var par in @params)
			{
				Console.Write(par.ParameterType + " : " + par.Name + " ");
			}
			Console.WriteLine();

#if !LOCAL_TEST

			var controllerFactory = new ControllerFactory(null);
			var requestHandler = new RequestHandler(controllerFactory);
			var socketHanler = new TPSocketHandler(requestHandler, new JsonSerializer());
			var server = new Server(socketHanler, ServerPort);
			server.Run();

			Console.WriteLine($"Server start on port: {ServerPort}");

			var client = TestClient();
			var req = TestGetRequest();
			var resp = await client.Get(req);

			Console.WriteLine($"Client recieve: {resp.JsonData}");
			await Task.Delay(1000000);
#endif
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
				Uri = "users/auth",
				Args = new Arg[]
				{
					TPRequest.BuildArg("pass", "pass11"),
					TPRequest.BuildArg("login", "login@gmail.com")
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
