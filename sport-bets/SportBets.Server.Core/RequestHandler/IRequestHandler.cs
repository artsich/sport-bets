using SportBets.Server.Core.Networking;
using System.Threading.Tasks;

namespace SportBets.Server.Core.RequestHandler
{
	public interface IRequestHandler
	{
		Task Handle(TPRequest request, TransferProtocol protocol);
	}
}
