using System;

namespace SportBets.Services.Models
{
	public class RegisterInfoUser
	{
		public string Name { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }

		public int Age { get; set; }
		public float Score { get; set; }
		public DateTime DateRegistration { get; set; }
	}

	public class RegistratedUser
	{
		public int Id { get; set; }
		public float Score { get; set; }
		public string Name { get; set; }
		public DateTime DateRegistration { get; set; }
		public int Age { get; set; }
	}

}
