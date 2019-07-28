using DudaTronReact.Controllers.Interfaces;
using DudaTronReact.Model;
using DudaTronReact.Model.SupportClasses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DudaTronReact.Controllers
{
	[Route("Wishes/[controller]")]
	[ApiController]
	public class GetWishController : BaseController
	{
		// POST: api/GetWish
		[HttpPost]
		public string Post([FromBody] string value)
		{
			ValidateRequest();
			UserEventParam getWishParam = JsonConvert.DeserializeObject<UserEventParam>(value);
			IWishReader wReader = new WishReader();
			Wish particularWish = wReader.GetWishForUserAndEvent(getWishParam);
			return JsonConvert.SerializeObject(particularWish);
		}
	}
}