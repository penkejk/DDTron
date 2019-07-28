using DudaTronReact.Controllers.Interfaces;
using DudaTronReact.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DudaTronReact.Controllers
{
	[Route("Events/[controller]")]
	[ApiController]
	public class CreateEventController : ControllerBase
	{
		// POST: api/CreateEvent
		[HttpPost]
		public void Post([FromBody] string value)
		{
			IEventWriter eWriter = new EventWriter();
			Event eventToCreate = JsonConvert.DeserializeObject<Event>(value);
			eWriter.CreateEvent(eventToCreate);
		}
	}
}