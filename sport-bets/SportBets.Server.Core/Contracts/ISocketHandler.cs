using System.Net.Sockets;
using System.Threading.Tasks;

namespace SportBets.Server.Core.Contracts
{
	public interface ISocketHandler
	{
		Task Process(Socket socket);
	}
}
