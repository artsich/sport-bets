using System.Net;

namespace SportBets.Server.Core.Networking
{
	public class Arg
	{
		public string Key { get; set; }
		public string Value { get; set; }
	}

	public class RequstHeader
	{
		public IPEndPoint IPEnd { get; set; }
	}

	public class TPRequest
    {
		//To
		public RequstHeader RemoteAddr { get; set; }
		
		//From
		public RequstHeader SenderAddr { get; set; }

		public string Uri { get; set; }
		public Arg[] Args { get; set; }

		public static Arg BuildArg(string key, string value)
		{
			return new Arg { Key = key, Value = value };
		}
    }
}