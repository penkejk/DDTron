using DudaTronReact.Controllers.Interfaces;
using DudaTronReact.Controllers.Security;
using DudaTronReact.Controllers.Security.Interfaces;
using DudaTronReact.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DudaTronReact.Controllers
{
	[Route("Wishes/[controller]")]
	[ApiController]
	public class UpdateWishController : ControllerBase
	{
		// POST: api/UpdateWish
		[HttpPost]
		public void Post([FromBody] string value)
		{
			ISecurityHelper security = new SecurityHelper();
			security.ValidateRequest(this.HttpContext);
			Wish updateWishValues = JsonConvert.DeserializeObject<Wish>(value);
			IWishWriter wWriter = new WishWriter();
			wWriter.UpdateWish(updateWishValues);
		}
	}
}