using System.Reflection;

namespace SportBets.Server.Core
{
	public class ControllerInfo
	{
		public IControllerMarker TargetController { get; set; }
		public MethodInfo TargetMethod { get; set; }
	}

}
