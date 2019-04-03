using System;
using System.Collections.Generic;
using System.Text;

namespace SportBets.Server.Core.Contracts.Serializer
{

	public interface ISerializer
	{
 		TOutput Serialize<TInput, TOutput>(TInput input);
		TInput Deserialize<TInput, TOutput>(TOutput input);
	}

}
