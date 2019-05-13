using System;

namespace SportBets.Server.Database.Entities
{
	public class PlacedBet : BaseEntity
	{
		public float Summa { get; set; }

		public DateTime DataPlaced { get; set; }

		public int? UserId { get; set; }
		public User User { get; set; }

		public int? BetResultId { get; set; }
		public BetResult BetResult { get; set; }
	}
}