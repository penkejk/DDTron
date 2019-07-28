using DudaTronReact.Controllers.Security;
using DudaTronReact.Controllers.Security.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudaTronReact.Controllers
{
	public class BaseController: ControllerBase
	{
		protected void ValidateRequest()
		{
			ISecurityHelper security = new SecurityHelper();
			security.ValidateRequest(this.HttpContext);
		}
	}
}
