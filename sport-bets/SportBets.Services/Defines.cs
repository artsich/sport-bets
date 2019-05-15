namespace SportBets.Services
{
	public static class Defines
	{
		public static string ServerIp = "127.0.0.1";
		public static int ServerPort = 5555;

		public static class UserServices
		{
			private static string UserController = "user";
			public static string GetAllUsers	= $"{UserController}/getall";
			public static string SignUpUserUrl	= $"{UserController}/signup";
			public static string SignInUserUrl	= $"{UserController}/signin";
			public static string GetUserByIdUrl = $"{UserController}/getbyid";
		}

		public static class EventServices
		{
			private static string EventController = "event";
			public static string CreateEvent	= $"{EventController}/create";
			public static string DeleteEvent	= $"{EventController}/delete";
			public static string UpdateEvent	= $"{EventController}/update";
			public static string GetEventById	= $"{EventController}/getbyid";
			public static string GetEvents		= $"{EventController}/get";
		}

		public static class BetService
		{
			private static string BetController = "bet";
			public static string GetBets = $"{BetController}/get";
			public static string GetBetById = $"{BetController}/getbyid";
			public static string MakeBet = $"{BetController}/makebet";
		}
	}
}