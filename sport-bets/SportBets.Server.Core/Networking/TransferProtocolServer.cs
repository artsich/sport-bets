using SportBets.Server.Core.Contracts.Serializer;
using System;
using System.Net.Sockets;
using System.Text;

namespace SportBets.Server.Core.Networking
{
	public class TransferProtocolServer
	{
		private readonly int BufferSize = 1_000_000;

		private Socket _socket;
		private ISerializer _serializer;

		public TransferProtocolServer(Socket socket, ISerializer serializer)
		{
			_socket = socket ?? throw new ArgumentNullException(nameof(socket));
			_serializer = serializer ?? throw new ArgumentOutOfRangeException(nameof(serializer));
		}

		public void Send<T>(T data) where T : class
		{
			if (data == null)
			{
				throw new ArgumentNullException(nameof(data));
			}

			var dataString = _serializer.Serialize(data);
			var sendingBuffer = Encoding.UTF8.GetBytes(dataString);

			//TODO: blocking method
			_socket.Send(sendingBuffer);
		}

		public T Receive<T>()
		{
			var buffer = new byte[BufferSize];
			//TODO: blocking method
			_socket.Receive(buffer);
			var str = Encoding.UTF8.GetString(buffer);
			var result = _serializer.Deserialize<T>(str);
			return result;
		}
	}
}