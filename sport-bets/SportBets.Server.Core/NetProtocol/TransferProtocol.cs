using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace SportBets.Server.Core.NetProtocol
{
    public class TransferProtocol
    {
		private Socket _endSocket;

		public TransferProtocol(Socket endPoint)
		{
			_endSocket = endPoint;
		}

		public void Send(TPRequest req)
		{
//			_endSocket.Send();
		}
    }
}
