using System;

namespace SportBets.Server.Database.Entities
{
	public class User : BaseEntity
	{
		public float Score { get; set; }

		public string Name { get; set; }
		public DateTime DateRegistration { get; set; }
		public int Age { get; set; }

		public string Login { get; set; }
		public string Password { get; set; }
	}
}