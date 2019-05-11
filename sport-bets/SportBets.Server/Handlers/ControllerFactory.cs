using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SportBets.Core.Networking;
using SportBets.Server.Core;
using SportBets.Server.Core.Handlers;
using SportBets.Server.Core.Networking;
using SportBets.Server.Services.Exceptions;

namespace SportBets.Server.Handlers
{
	public class ControllerFactory : IControllerFactory
	{
		//TODO: _need make readonly, recieve types contollers from out.
		private IDictionary<string, Type> _nameTypeContollers;

		public ControllerFactory(IDictionary<string, Type> nameTypeContollers)
		{
			_nameTypeContollers = nameTypeContollers;
			_nameTypeContollers.Add("login", typeof(Type));
			_nameTypeContollers.Add("bets", typeof(Type));
			_nameTypeContollers.Add("users", typeof(Type));
		}

		public IController Process(string uri, Arg[] args)
		{
			if(string.IsNullOrEmpty(uri))
			{
				throw new ControllerException(ControllerError.ControllerNotFound);
			}

			var query = uri?.Split('/');

			if (query.Length < 2)
			{
				throw new ControllerException(ControllerError.MethodNotFound);
			}

			var typeControllerInfo = GetControllerByName(query[0]);
			IController result = null;

			if (typeControllerInfo != null)
			{
				var methodInfo = GetMethodByNameAndParams(typeControllerInfo, query[1], args);

				if (methodInfo != null)
				{
					var obj = Activator.CreateInstance(typeControllerInfo);
					result = obj as IController;

					if(result == null)
					{
						throw new ControllerException(ControllerError.ControllerNotFound);
					}
				}
				else
				{
					throw new ControllerException(ControllerError.MethodNotFound);
				}
			}
			else
			{
				throw new ControllerException(ControllerError.ControllerNotFound);
			}

			return result;
		}

		private Type GetControllerByName(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				return null;
			}

			_nameTypeContollers.TryGetValue(name, out var controller);
			return controller;
	    }

		private MethodInfo GetMethodByNameAndParams(Type obj, string name, Arg[] args)
		{
			//	obj.GetMethods().Where();
			return null;
		}
	}
}
