using SportBets.Core.Networking;
using SportBets.Core.Serializer;
using SportBets.Server.Core;
using SportBets.Server.Core.Handlers;
using SportBets.Server.Core.Networking;
using SportBets.Server.Services;
using SportBets.Server.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SportBets.Server.Handlers
{
	public class ControllerHandler : IControllerHandler
	{
		private static IDictionary<string, Type> _nameTypeContollers = new Dictionary<string, Type>();
		private readonly string CONTROLLER = "controller";

		ISerializer serializer;

		public ControllerHandler()
		{
			serializer = new JsonSerializer();
		}

		static ControllerHandler()
		{
			var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
			   .Where(x => typeof(IControllerMarker).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

			foreach (var type in types)
			{
				_nameTypeContollers.Add(type.Name.ToLower(), type);
			}
		}

		public void Execute(RequestContext requestContext)
		{
			var args = requestContext.Request.Args ?? new Arg[0];
			var uri = requestContext.Request.Uri;

			var controllerInfo = Find(uri, args);
			var @params = TransformArg(args);

			var result = controllerInfo.TargetMethod.Invoke(controllerInfo.TargetController, @params);
			var disposableController = controllerInfo.TargetController as IDisposable;
			disposableController?.Dispose();

			if (result != null)
			{
				requestContext.Responce.Status = StatusCode.OK;
				requestContext.Responce.JsonData = serializer.Serialize(result);
			}
		}

		private object[] TransformArg(Arg[] args)
		{
			return args.Select(x => (object)x.Value).ToArray();
		}

		private ControllerInfo Find(string uri, Arg[] args)
		{
			if (string.IsNullOrEmpty(uri))
			{
				throw new ControllerException(ControllerError.ControllerNotFound);
			}

			var query = uri?.Split('/');

			if (query.Length < 2)
			{
				throw new ControllerException(ControllerError.MethodNotFound);
			}

			var typeControllerInfo = GetControllerByName(query[0]) ?? throw new ControllerException(ControllerError.ControllerNotFound);			IControllerMarker result = null;

			var methodInfo = GetMethodByNameAndParams(typeControllerInfo, query[1], args);
			methodInfo = methodInfo ?? throw new ControllerException(ControllerError.ControllerNotFound);

			var obj = Activator.CreateInstance(typeControllerInfo);
			result = obj as IControllerMarker ?? throw new ControllerException(ControllerError.MethodNotFound);

			return new ControllerInfo
			{
				TargetController = result,
				TargetMethod = methodInfo
			};
		}

		private Type GetControllerByName(string name)
		{
			_nameTypeContollers.TryGetValue(name + CONTROLLER, out var controller);
			return controller;
		}

		private MethodInfo GetMethodByNameAndParams(Type obj, string name, Arg[] args)
		{
			var method = obj.GetMethods().Where(x => x.Name.ToLower().Equals(name)).FirstOrDefault();
			if (method == null)
			{
				return null;
			}

			var parameters = method.GetParameters();
			if (parameters == null)
			{
				return null;
			}

			if (parameters.Length == args.Length)
			{
				for (int i = 0; i < parameters.Length; ++i)
				{
					if (!parameters[i].Name.ToLower()
						.Equals(args[i].Key.ToLower()))
					{
						return null;
					}
				}
				return method;
			}
			return null;
		}
	}
}