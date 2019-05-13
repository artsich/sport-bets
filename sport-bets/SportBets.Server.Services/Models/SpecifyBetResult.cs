using System.Collections.Generic;

namespace SportBets.Server.Services.Models
{
	public class BetResultInfo
	{
		public int BetId { get; set; }
		public ICollection<(int resultId, bool result)> Resutls;
	}
}
