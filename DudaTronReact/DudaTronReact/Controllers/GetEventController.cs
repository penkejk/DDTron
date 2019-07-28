using DudaTronReact.Controllers.Interfaces;
using DudaTronReact.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace DudaTronReact.Controllers
{
	[Route("Events/[controller]")]
	[ApiController]
	public class GetEventController : ControllerBase
	{
		// GET: api/GetEvent
		[HttpGet]
		public IEnumerable<string> Get()
		{
			IEventReader eReader = new EventReader();
			IEnumerable<Event> eventsOnDb = eReader.GetEvents();

			return eventsOnDb.Select(eventInTheList => JsonConvert.SerializeObject(eventInTheList));
		}

		// GET: api/GetEvent/5
		[HttpGet("{id}", Name = "GetEvent")]
		public string Get(int id)
		{
			IEventReader eReader = new EventReader();
			return JsonConvert.SerializeObject(eReader.GetEvent(id));
		}
	}
}