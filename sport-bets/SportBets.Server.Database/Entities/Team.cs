namespace SportBets.Server.Database.Entities
{
	public class Team : BaseEntity
	{
		public string Name { get; set; }

		public int? TypeSportId { get; set; }
		public TypeSport TypeSport { get; set; }
	}
}