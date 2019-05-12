using System;
using System.Text;
using System.Net.Sockets;
using SportBets.Core.Serializer;

namespace SportBets.Server.Core.Networking
{
	public class TransferProtocolServer
	{
		private readonly int ReceiveBufferSize = 1_000_000;
		private readonly int SendBufferSize = 1_000_000;

		private Socket _socket;
		private ISerializer _serializer;

		public TransferProtocolServer(Socket socket, ISerializer serializer)
		{
			_socket = socket;

			_socket.SendBufferSize = SendBufferSize;
			_socket.ReceiveBufferSize = ReceiveBufferSize;

			_serializer = serializer;
		}

		public void Send<T>(T data) where T : class
		{
			if (data == null)
			{
				throw new ArgumentNullException(nameof(data));
			}

			var dataString = _serializer.Serialize(data);
			var sendingBuffer = Encoding.UTF8.GetBytes(dataString);

			_socket.Send(sendingBuffer);
		}

		public T Receive<T>()
		{
			var buffer = new byte[ReceiveBufferSize];
			_socket.Receive(buffer);
			var str = Encoding.UTF8.GetString(buffer);
			var result = _serializer.Deserialize<T>(str);
			return result;
		}
	}
}