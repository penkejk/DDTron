using DudaTronReact.Controllers.Security;
using DudaTronReact.Controllers.Security.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DudaTronReact.Controllers
{
	[Route("Users/[controller]")]
	[ApiController]
	public class LogOutController : ControllerBase
	{
		// GET: api/LogOut/5
		[HttpGet("{id}", Name = "Logout")]
		public void Get(int id)
		{
			ISecurityHelper secHelper = new SecurityHelper();
			secHelper.KillSessionForUserId(id);
		}
	}
}