using DudaTronReact.Controllers.Interfaces;
using DudaTronReact.Exceptions;
using DudaTronReact.Model;

namespace DudaTronReact.Controllers
{
	public class EventWriter : IEventWriter
	{
		private IDataBaseReader dbr;
		private IEventReader evReader;

		public EventWriter()
		{
			this.dbr = new DataBaseReader();
			this.evReader = new EventReader();
		}

		public void CreateEvent(Event eventdb)
		{
			if (evReader.GetEvent(eventdb.Name) != null)
			{
				throw new EventAlreadyExistsException("The event with this name already exists");
			}

			string insertEvent = "insert into Events (Name) values (@Name)";
			dbr.InsertData(insertEvent, eventdb);
		}

		public void UpdateEvent(Event eventdb)
		{
			if (evReader.GetEvent(eventdb.Id) != null)
			{
				throw new EventAlreadyExistsException("The event does not exists");
			}

			string updateEvent = "update Events set Name =@Name where Id = @Id";
			dbr.InsertData(updateEvent, eventdb);
		}

		public void DeleteEvent(Event eventdb)
		{
			string deleteEvent = "delete Events where Name = @Name";
			dbr.InsertData(deleteEvent, eventdb);
		}
	}
}