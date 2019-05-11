using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportBets.Core
{
	public enum Page
	{
		Home,
		History,
		SignUp
	}

	static class Defines
	{
		public static string ServerIp = "127.0.0.1";
		public static int ServerPort = 5555;

		public static string SignUpUserUrl = "user/signup";
		public static string SignInUserUrl = "user/signin";
	}


}
