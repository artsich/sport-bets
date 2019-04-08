using System.Net;
using System.Net.Sockets;

namespace SportBets.Server.Core.Networking
{
	public class Arg
	{
		public string Key { get; set; }
		public string Value { get; set; }

		public override string ToString()
		{
			return Key + "=" + Value;
		}
	}

	public class Header
	{
		public string Address { get; set; }
		public AddressFamily AddressFamily { get; set; }
		public int Port { get; set; }
	}

	public class TPRequest
    {
		//To
		public Header Header { get; set; }

		public string Uri { get; set; }
		public Arg[] Args { get; set; }

		public static Arg BuildArg(string key, string value)
		{
			return new Arg { Key = key, Value = value };
		}
    }
}