using DudaTronReact.Controllers.Interfaces;
using DudaTronReact.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace DudaTronReact.Controllers
{
	[Route("Users/[controller]")]
	[ApiController]
	public class UpdateUserController : BaseController
	{
		// POST: api/UpdateUser
		[HttpPost]
		public void Post([FromBody] string value)
		{
			ValidateRequest();

			User newUserDetails = JsonConvert.DeserializeObject<User>(value);
			IUserWriter iWriter = new UserWriter();
			if (Convert.ToInt32(this.HttpContext.Request.Headers["UserId"]) == newUserDetails.Id)
			{
				iWriter.UpdateUser(newUserDetails);
			}
		}
	}
}