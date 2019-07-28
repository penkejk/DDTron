using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudaTronReact.Controllers.Security.Interfaces
	{
	public interface ISecurityHelper
	{
		string HashPassword(string password, int saltLength);
		bool CheckIfPasswordMatches(string password, string newPassword, int saltLength);
		Guid CreateLoginSession(int userId);
		void KillSessionForUserId(int userId);
		bool GetCurrentSessionState(IdSession session);
		void ValidateRequest(HttpContext context);
	}
}
