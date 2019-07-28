using DudaTronReact.Controllers.Interfaces;
using DudaTronReact.Controllers.SupportClasses;
using Microsoft.AspNetCore.Mvc;

namespace DudaTronReact.Controllers
{
	[Route("Users/[controller]")]
	[ApiController]
	public class DeleteUserController : ControllerBase
	{
		// POST: api/DeleteUser
		[HttpPost]
		public void Post([FromBody] string value)
		{
			DeleteUserParam delUser = Newtonsoft.Json.JsonConvert.DeserializeObject<DeleteUserParam>(value);
			IUserWriter userWriter = new UserWriter();
			userWriter.DeleteUser(delUser);
		}
	}
}