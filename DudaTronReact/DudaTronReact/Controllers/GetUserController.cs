using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DudaTronReact.Controllers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DudaTronReact.Controllers
{
    [Route("UserData/[controller]")]
    [ApiController]
    public class GetUserController : ControllerBase
    {
    
        // GET: api/GetUser/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
			IUserReader reader = new UserReader();
			return JsonConvert.SerializeObject(reader.GetUser(id));
        }

        
    }
}
