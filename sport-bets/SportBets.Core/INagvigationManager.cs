using System;
using System.Collections.Generic;
using System.Text;

namespace SportBets.Core.Contracts
{
	public enum Page
	{
		Home,
		History,
		SignUp,
		SignIn
	}

	public interface INagvigationManager
	{
		void NavigateTo(Page page);
	}
}