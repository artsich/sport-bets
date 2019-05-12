using SportBets.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportBets.Services.Interfaces
{
	public interface IEventService
	{
		Task<EventInfo> Create(CreatingEventInfo ev);
		Task<EventInfo> Update(EventInfo ev);
		Task<JustResult> Delete(int id);
		Task<EventInfo> GetById(int id);
		Task<IEnumerable<EventInfo>> Get();

	}
}
