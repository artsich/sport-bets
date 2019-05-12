using System;
using SportBets.Core;
using SportBets.Core.WebApi;
using System.Threading.Tasks;
using SportBets.Core.Serializer;
using SportBets.Services.Models;
using System.Collections.Generic;
using SportBets.Services.Interfaces;

namespace SportBets.Services.Services
{
	public class EventService : IEventService
	{
		private IWebApi _webApi;
		private ISerializer _serializer;

		public EventService(IWebApi webApi, ISerializer serializer)
		{
			_webApi = webApi;
			_serializer = serializer;
		}

		public async Task<EventInfo> Create(CreatingEventInfo ev)
		{
			var args = new ArgsBuilder()
				.Add(nameof(ev.Name), ev.Name)
				.Add(nameof(ev.DataTime), ev.DataTime.ToString())
				.Add(nameof(ev.Teams), _serializer.Serialize(ev.Teams))
				.Build();

			var result = await _webApi.Query<EventInfo>(Defines.EventServices.CreateEvent, args);
			return result.Responce;
		}

		public async Task<JustResult> Delete(int id)
		{
			var args = new ArgsBuilder()
				.Add(nameof(id), id.ToString())
				.Build();

			var result = await _webApi.Query<JustResult>(Defines.EventServices.CreateEvent, args);
			return result.Responce;
		}

		public async Task<IEnumerable<EventInfo>> Get()
		{
			var result = await _webApi.Query<IEnumerable<EventInfo>>(Defines.EventServices.GetEvents);
			return result.Responce;
		}

		public Task<EventInfo> Update(EventInfo ev)
		{
			throw new NotImplementedException();
		}

		public async Task<EventInfo> GetById(int id)
		{
			var args = new ArgsBuilder()
				.Add(nameof(id), id.ToString())
				.Build();
			
			var result = await _webApi.Query<EventInfo>(Defines.EventServices.GetEventById, args);
			return result.Responce;
		}
	}
}
