using Newtonsoft.Json;
using SportBets.Server.Core.Contracts.Serializer;

namespace SportBets.Core.Serializer
{
	public class JsonSerializer : ISerializer
	{
		private JsonSerializerSettings _jsonSetting;

		public JsonSerializer() : this(new JsonSerializerSettings())
		{			
		}

		public JsonSerializer(JsonSerializerSettings jsonSetting)
		{
			_jsonSetting = jsonSetting;
		}

		public TOutput Deserialize<TOutput>(string value)
		{
			var result = JsonConvert.DeserializeObject<TOutput>(value);
			return result;
		}

		public string Serialize<TInput>(TInput input)
		{
			var result = JsonConvert.SerializeObject(input, _jsonSetting); 		
			return result;
		}
	}
}
