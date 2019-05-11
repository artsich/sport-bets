using System.Linq;
using SportBets.Core.Networking;
using System.Collections.Generic;

namespace SportBets.Core
{
	public class ArgsBuilder
	{
		IList<Arg> _args;

		public ArgsBuilder()
		{
			_args = new List<Arg>();
		}

		public ArgsBuilder Add(string key, string value)
		{
			_args.Add(new Arg { Key = key, Value = value });
			return this;
		}

		public Arg[] Build()
		{
			var list = _args;
			_args = new List<Arg>();
			return list.ToArray();
		}
	}

}
