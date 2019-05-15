using System.Collections.Generic;

namespace SportBets.Services.Models
{
	public class CreatedInfoBet
	{
		public string Name { get; set; }
		public EventInfo Event { get; set; }
		public ICollection<BetResult> Results { get; set; }

		public CreatedInfoBet()
		{
			Results = new List<BetResult>();
		}
	}

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

	public class MakeBetResult
	{
		public bool Result { get; set; }
	}

	public class BetResult 
	{
		public int Id { get; set; }

		public string Description { get; set; }
		public float Coefficient { get; set; }
	}
}