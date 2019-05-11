using System.Threading.Tasks;
using SportBets.Core.Networking;
using SportBets.Core.Serializer;

namespace SportBets.Core.WebApi
{
	public class WebApi : IWebApi
	{
		private readonly ISerializer _serializer;
		private readonly Header _header;

		public WebApi(ISerializer serializer, Header header)
		{
			_serializer = serializer;
			_header = header;
		}

		public async Task<WebResult<T>> Query<T>(string uri, Arg[] args)
		{
			var tpc = new TransferProtocolClient(_serializer);
			var request = new TPRequest()
			{
				Header = _header,
				Uri = uri,
				Args = args
			};

			var resp = await tpc.Get(request);

			return new WebResult<T>()
			{
				Status = resp.Status,
				Responce = _serializer.Deserialize<T>(resp.JsonData)
			};
		}
	}
}