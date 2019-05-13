using System.Collections.Generic;

namespace SportBets.Server.Database.Entities
{
	public class Bet : BaseEntity
	{
		public string Name { get; set; }

		public virtual ICollection<BetResult> Results { get; set; }

		public int? EventId { get; set; }
		public virtual Event Event { get; set; }

		public Bet()
		{
			Results = new List<BetResult>();
		}
	}

	public class BetResult : BaseEntity
	{
		public int? BetId { get; set; }
		public virtual Bet Bet { get; set; }

		public string Description { get; set; }
		public float Coefficient { get; set; }

		public bool? Result { get; set; }
	}
}