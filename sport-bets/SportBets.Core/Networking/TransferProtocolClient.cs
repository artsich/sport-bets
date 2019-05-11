using System;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using SportBets.Core.Networking;
using SportBets.Core.Serializer;

namespace SportBets.Core.Networking
{
	public class TransferProtocolClient
	{
		private readonly int BufferSize = 1_000_000;
		private ISerializer _serializer;

		public TransferProtocolClient(ISerializer serializer)
		{
			_serializer = serializer;
		}

		public async Task<TPResponse> Get(TPRequest request)
		{
			if(request == null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			return await Task.Run( () =>
			{
				TPResponse response;
				using (Socket socket = new Socket(request.Header.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
				{
					//socket.Bind(new IPEndPoint(IPAddress.Any, 0));
					EndPoint remoteAddr = null;
					try
					{
						remoteAddr = new IPEndPoint(IPAddress.Parse(request.Header.Address), request.Header.Port);
					}
					catch (FormatException e)
					{
						throw new FormatException(e.Message);
					}

					socket.Connect(remoteAddr);

					var dataString = _serializer.Serialize(request);
					var sendingBuffer = Encoding.UTF8.GetBytes(dataString);
					socket.Send(sendingBuffer);

					var buffer = new byte[BufferSize];
					socket.Receive(buffer);

					var receivedData = Encoding.UTF8.GetString(buffer);
					response = _serializer.Deserialize<TPResponse>(receivedData);
				}
				return response;
			});
		}
	}
}
