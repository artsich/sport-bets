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
		private readonly int ReceiveBufferSize = 1_000_000;
		private readonly int SendBufferSize = 1_000_000;

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
				TPResponse response = null;
				using (Socket socket = new Socket(request.Header.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
				{
					try
					{
						EndPoint remoteAddr = new IPEndPoint(IPAddress.Parse(request.Header.Address), request.Header.Port);
						socket.Connect(remoteAddr);

						var dataString = _serializer.Serialize(request);
						var sendingBuffer = Encoding.UTF8.GetBytes(dataString);
						socket.Send(sendingBuffer);

						var buffer = new byte[ReceiveBufferSize];
						socket.Receive(buffer);

						var receivedData = Encoding.UTF8.GetString(buffer);
						response = _serializer.Deserialize<TPResponse>(receivedData);
					}
					catch (FormatException e)
					{
						throw new FormatException(e.Message);
					}
					catch (Exception ex)
					{
						response = new TPResponse()
						{
							JsonData = string.Empty,
							Status = StatusCode.NotFound
						};
					}
				}
				return response;
			});
		}
	}
}
