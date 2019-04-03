namespace SportBets.Server.Core.NetProtocol
{
	public class Arg
	{
		public string Key { get; set; }
		public string Value { get; set; }
	}

    public class TPRequest
    {
		public string Url { get; set; }
		public Arg[] Args { get; set; }

		public static Arg BuildArg(string key, string value)
		{
			return new Arg { Key = key, Value = value };
		}
    }
}
