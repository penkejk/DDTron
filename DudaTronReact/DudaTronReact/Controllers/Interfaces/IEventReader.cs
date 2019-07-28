using DudaTronReact.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudaTronReact.Controllers.Interfaces
{
	public interface IEventReader
	{
		IEnumerable<Event> GetEvents();
		Event GetEvent(int eventId);
		Event GetEvent(string eventName);
	}
}
