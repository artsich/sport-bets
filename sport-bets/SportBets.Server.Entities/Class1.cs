using System;
using System.Collections.Generic;
using System.Text;

namespace SportBets.Server.Entities
{

	public class PlaceBet
	{
		public int Id { get; set; }

		public int? UserId { get; set; }
		public virtual User Person { get; set; }

		public int? BetId { get; set; }

	}

	public class Bet
	{
		public int Id { get; set; }
		public float Coefficient { get; set; }	
	}

	//TODO: Rename
	public class HardBet
	{
		public int Id { get; set; }
		public string NameBet { get; set; }

		//Store args of bets name-bet:coefficient
		public IDictionary<string, float> f;
	}

    public class User
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public int Ballance { get; set; }

		public int Login { get; set; }
		public int Password { get; set; }
    }
}
