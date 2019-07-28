using DudaTronReact.Controllers.Security.Interfaces;
using DudaTronReact.Controllers.Secutity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DudaTronReact.Controllers.Security
{
	[Route("Users/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		// POST: Users/Login
		[HttpPost]
		public string Post([FromBody] string value)
		{
			LoginPassword loginPassword = JsonConvert.DeserializeObject<LoginPassword>(value);
			ILoginHelper ilHelper = new LoginHelper();
			return JsonConvert.SerializeObject(ilHelper.Login(loginPassword));
		}
	}
}