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

		class A
		{
			public string value { get; set; }
		}

		public static async Task Main(string[] args)
		{
			var server = new Server(
				new TPSocketHandler(
					new RequestHandler()), ServerPort);

			server.Run();

			Console.WriteLine($"Server start on port: {ServerPort}");

			var request = new TPRequest()
			{
				Uri = "users/auth",
				Args = new Arg[] 
				{
					TPRequest.BuildArg("pass", "pass11"),
					TPRequest.BuildArg("login", "login@gmail.com")
				}
			};

			var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			var localPoint = new IPEndPoint(IPAddress.Loopback, 6666);
			var remotePoint = new IPEndPoint(IPAddress.Loopback, ServerPort);

			socket.Bind(localPoint);
			socket.Connect(remotePoint);

			var json = new JsonSerializer();
			var tp = new TransferProtocol(socket, json);
			tp.Send(request);
			var resp = tp.Receive<TPResponse>();
//			var data = json.Deserialize<A>(resp.JsonData);

			Console.WriteLine(resp.JsonData);

			await Task.Delay(1000);
			//var message = Encoding.UTF8.GetBytes("test-server.");
			//socket.Send(message);

			await Task.Delay(1000000);
		}
	}
}
