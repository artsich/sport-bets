using SportBets.Server.Core.Contracts.Networking;
using SportBets.Server.Core.NetProtocol.Handlers;
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
	class Server
	{
		private const int Backlog = 512;

		private int _port;
		private bool _running = false;
		private Socket _socketServer;
		private IPEndPoint _localPoint;
		private Thread _mainThread;
		private ISocketHandler _clientHandler;
		private TPSocketHandler tPSocketHandler;
		private int serverPort;

		private int Port
		{
			get => _port;
			set
			{
				if (!_running)
				{
					_port = value;
				}
			}
		}

		public Server(ISocketHandler clientHandler, int port)
		{
			_port = port;
			_clientHandler = clientHandler;
		}

		public Server(TPSocketHandler tPSocketHandler, int serverPort)
		{
			this.tPSocketHandler = tPSocketHandler;
			this.serverPort = serverPort;
		}

		public void Run()
		{
			Init();
			_mainThread = new Thread((async () =>
			{
				_running = true;
				_socketServer.Bind(_localPoint);
				_socketServer.Listen(Backlog);

				while (_running)
				{
					var socket = _socketServer.Accept();
					await _clientHandler.Process(socket);
				}

				_socketServer?.Dispose();
			}));
			_mainThread.Start();

		}

		public void Close()
		{
			_running = false;
		}

		private void Init()
		{
			_socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			_localPoint = new IPEndPoint(IPAddress.Any, _port);
		}
	}
}
