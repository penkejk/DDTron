using DudaTronReact.Controllers.Interfaces;
using DudaTronReact.Model;
using System.Collections.Generic;

namespace DudaTronReact.Controllers
{
	public class EventReader : IEventReader
	{
		private IDataBaseReader dbr;

		public EventReader()
		{
			dbr = new DataBaseReader();
		}

		public IEnumerable<Event> GetEvents()
		{
			string getEvents = "select * from Events order by id asc";
			return dbr.GetData<Event>(getEvents);
		}

		public Event GetEvent(string eventName)
		{
			string getEvent = $"select * from Events where name ='{eventName}'";
			return dbr.GetSingleOrDefault<Event>(getEvent); ;
		}

		public Event GetEvent(int id)
		{
			string getEvent = $"select * from Events where Id ={id}";
			return dbr.GetSingleOrDefault<Event>(getEvent); ;
		}
	}
}