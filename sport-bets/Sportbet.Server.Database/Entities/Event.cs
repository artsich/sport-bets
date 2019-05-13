using System;
using System.Collections.Generic;

namespace SportBets.Server.Database.Entities
{
	public class Event : BaseEntity
	{
		public string Name { get; set; }
		public DateTime DataTime { get; set; }

		public int? TypeSportId { get; set; }
		public TypeSport TypeSport { get; set; }

		public virtual ICollection<Team> Teams { get; set; }

		public Event()
		{
			Teams = new List<Team>();
		}
	}
}
