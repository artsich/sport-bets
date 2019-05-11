using System.Threading.Tasks;
using SportBets.Core.Networking;

namespace SportBets.Core.WebApi
{
    public interface IWebApi
    {
		Task<WebResult<T>> Query<T>(string uri, Arg[] args);
	}
}
