using DudaTronReact.Controllers.Interfaces;
using DudaTronReact.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DudaTronReact.Controllers
{
	[Route("Users/[controller]")]
	[ApiController]
	public class CreateUserController : ControllerBase
	{
		// GET: api/CreateUser
		[HttpGet]
		public string Get()
		{
			User userToReturn = new User
			{
				Email = "sample mail",
				Id = 99,
				LastName = "LastName",
				Name = "Name"
			};
			return JsonConvert.SerializeObject(userToReturn);
		}

		// POST: api/CreateUser
		[HttpPost]
		public void Post([FromBody] string value)
		{
			UserWithPassword newUser = JsonConvert.DeserializeObject<UserWithPassword>(value);
			IUserWriter userWriter = new UserWriter();
			userWriter.CreateUser(newUser);
		}
	}
}