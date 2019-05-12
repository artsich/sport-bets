using System;

namespace SportBets.Server.Services.Exceptions
{
	public enum ControllerError
	{
		ControllerNotFound,
		MethodNotFound,
		InvalidAguments
	}

	public class ControllerException : Exception
	{
		public ControllerError Error { get; set; }

		public ControllerException(ControllerError error)
		{
			Error = error;
		}

		public ControllerException(ControllerError error, string message) :
			base(message)
		{
			Error = error;
		}
	}
}
