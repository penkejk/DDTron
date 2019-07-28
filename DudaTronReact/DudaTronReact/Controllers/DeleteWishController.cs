using DudaTronReact.Controllers.Interfaces;
using DudaTronReact.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DudaTronReact.Controllers
{
	[Route("Wishes/[controller]")]
	[ApiController]
	public class DeleteWishController : BaseController
	{
		// POST: api/DeleteWish
		[HttpPost]
		public void Post([FromBody] string value)
		{
			ValidateRequest();
			Wish wishToDelete = JsonConvert.DeserializeObject<Wish>(value);
			IWishWriter wWriter = new WishWriter();
			wWriter.DeleteWish(wishToDelete);
		}
	}
}