using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DudaTronReact.Controllers.Interfaces;
using DudaTronReact.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DudaTronReact.Controllers
{
    [Route("Users/[controller]")]
    [ApiController]
    public class ChangePasswordController : BaseController
    {


        // POST: api/ChangePassword
        [HttpPost]
        public void Post([FromBody] string value)
        {
			ValidateRequest();
			UserWithPassword newUserDetails = JsonConvert.DeserializeObject<UserWithPassword>(value);
			IUserWriter iWriter = new UserWriter();
			if (Convert.ToInt32(this.HttpContext.Request.Headers["UserId"]) == newUserDetails.Id)
			{
				iWriter.UpdatePassword(newUserDetails);
			}
		}

    }
}
