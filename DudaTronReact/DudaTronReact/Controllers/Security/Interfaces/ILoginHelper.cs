using DudaTronReact.Controllers.Secutity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudaTronReact.Controllers.Security.Interfaces
{
	public interface ILoginHelper
	{
		/// <summary>
		/// Returns user's id. In case login data does not match the database state returns 0;
		/// </summary>
		/// <param name="loginPassword"></param>
		/// <returns></returns>
		IdSession Login(LoginPassword loginPassword);
	}
}
