using SportBets.Server.Core.Contracts;
using SportBets.Server.Core.Contracts.Networking;
using SportBets.Server.Core.NetProtocol;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SportBets.Server.Core.NetProtocol.Handlers
{
	public class TPSocketHandler : ISocketHandler
	{
		public async Task Process(Socket socket)
		{
			var tp = new TransferProtocol(socket);

			await Task.Run(() =>
			{
				var endPoint = (IPEndPoint)socket.RemoteEndPoint;
				byte[] buffer = new byte[128];
				socket.Receive(buffer);
				var message = ToText(buffer);

				Console.WriteLine($"try connect from {endPoint.Address} : {endPoint.Port} -> {message}");
			});
		}

		private string ToText(byte[] buffer)
		{
			var message = Encoding.UTF8.GetString(buffer);
			var reg = new Regex("[A-z]|[0-9]", RegexOptions.Compiled);
			var matches = reg.Matches(message);
			var builder = new StringBuilder();

			foreach (var match in matches)
			{
				builder.Append(((Match)match).Value);
			}

			return builder.ToString();
		}
	}
}
