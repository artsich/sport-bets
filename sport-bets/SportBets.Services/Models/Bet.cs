using System.Collections.Generic;

namespace SportBets.Services.Models
{
	public class Bet
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public EventInfo Event { get; set; }
		public ICollection<BetResult> Results { get; set; }

		public Bet()
		{
			Results = new List<BetResult>();
		}
	}

	public class BetResult 
	{
		public int Id { get; set; }
		public Bet Bet { get; set; }

		public string Description { get; set; }
		public float Coefficient { get; set; }
	}
}