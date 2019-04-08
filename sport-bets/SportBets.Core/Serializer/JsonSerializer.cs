using Newtonsoft.Json;
using SportBets.Server.Core.Contracts.Serializer;

namespace SportBets.Core.Serializer
{
	public class JsonSerializer : ISerializer
	{
		public TOutput Deserialize<TOutput>(string value)
		{
			var result = JsonConvert.DeserializeObject<TOutput>(value);
			return result;
		}

		public string Serialize<TInput>(TInput input)
		{
			var result = JsonConvert.SerializeObject(input);
			return result;
		}
	}
}
