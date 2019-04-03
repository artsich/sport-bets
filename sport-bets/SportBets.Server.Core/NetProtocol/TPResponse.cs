using System;

namespace SportBets.Server.Core.NetProtocol
{
	public enum TypeContent
	{
		JSON
	}

    public class TPResponse
    {
		public object Content { get; set; }
		public Type Type { get; set; }
    }
}
