using System;
using System.Collections.Generic;

namespace SportBets.Services.Models
{
	public class CreatingEventInfo
	{
		public string Name { get; set; }
		public DateTime DataTime { get; set; }
		public ICollection<Team> Teams { get; set; }

		public CreatingEventInfo()
		{
			Teams = new List<Team>();
		}
	}

	public class EventInfo
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<Team> Teams { get; set; }

		public ICollection<Bet> Bets { get; set; }

		public EventInfo()
		{
			Teams = new List<Team>();
		}
	}

	public class Team
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public TypeSport TypeSport { get; set; }
	}

	public class TypeSport
	{		
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
