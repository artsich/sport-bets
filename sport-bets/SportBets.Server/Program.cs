using SportBets.Server.Core.Handlers;
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
			var server = new Server(new SocketHandler(), ServerPort);
			server.Run();
			Console.WriteLine($"Server start on port: {ServerPort}");
			var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			var localPoint = new IPEndPoint(IPAddress.Loopback, 6666);
			var remotePoint = new IPEndPoint(IPAddress.Loopback, ServerPort);

			await Task.Delay(1000);
			socket.Bind(localPoint);
			socket.Connect(remotePoint);			
			var message = Encoding.UTF8.GetBytes("Hello-world.");
			socket.Send(message);

			await Task.Delay(1000000);
		}
	}
}
