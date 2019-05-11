using SportBets.Core.Networking;

namespace SportBets.Core.WebApi
{
	public class WebResult<T>
	{
		public StatusCode Status { get; set; }
		public T Responce { get; set; }
	}
}
