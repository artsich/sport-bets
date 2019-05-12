using SportBets.Core.Networking;

namespace SportBets.Server.Core
{
	public class RequestContext
	{
		public TPRequest Request { get; }
		public TPResponse Responce { get; set; }

		public RequestContext(TPRequest request)
		{
			Request = request;
		}
	}
}
