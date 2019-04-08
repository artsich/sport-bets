namespace SportBets.Server.Core.Networking
{
	public enum StatusCode
	{
		OK = 200,
		NotFound = 404,
		MethodNotAllowed = 405,
	}

	public class TPResponse
    {
		public string JsonData { get; set; }
		public StatusCode Status { get; set; }	
    }
}