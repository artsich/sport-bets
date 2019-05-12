using System.Data.Entity;

namespace SportBets.Server.Database.Entities
{
	public class BetsDbContext : DbContext
	{
		public BetsDbContext() :
			base("SportBetsDataBase")
		{
		}

		public DbSet<User> Users { get; set; }

		public DbSet<PlacedBet> PlacedBets { get; set; }

		public DbSet<Bet> Bets { get; set; }

		public DbSet<Event> Events { get; set; }

		public DbSet<Team> Teams { get; set; }

		public DbSet<TypeSport> SportTypes { get; set; }
	}
}