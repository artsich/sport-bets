using SportBets.Server.Core.Contracts;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SportBets.Server.Core.Handlers
{
	public class SocketHandler : ISocketHandler
	{
		public async Task Process(Socket socket)
		{
			await Task.Run(() =>
			{
				var endPoint = (IPEndPoint)socket.RemoteEndPoint;
				byte[] buffer = new byte[128];
				socket.Receive(buffer);
				var message = Encoding.UTF8.GetString(buffer);
				Console.WriteLine($"try connect from {endPoint.Address} : {endPoint.Port} -> {message}");
			});
		}
	}
}
