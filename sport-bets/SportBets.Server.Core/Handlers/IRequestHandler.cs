using System.Threading.Tasks;
using SportBets.Core.Networking;
using SportBets.Server.Core.Networking;

namespace SportBets.Server.Core.Handlers
{
	public interface IRequestHandler
	{
		Task Handle(TPRequest request, TransferProtocolServer protocol);
	}
}
