using SportBets.Services.Models;

namespace SportBets.Win10.Bihevior
{
	public class AuthUserManager
	{
		public RegistratedUser User { get; set; }
		public bool IsAuthorize { get => User != null; }
	}
}