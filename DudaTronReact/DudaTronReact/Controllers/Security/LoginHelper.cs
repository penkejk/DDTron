using DudaTronReact.Controllers.Interfaces;
using DudaTronReact.Controllers.Security.Interfaces;
using DudaTronReact.Controllers.Secutity;
using DudaTronReact.Model;
using System;

namespace DudaTronReact.Controllers.Security
{
	public class LoginHelper : ILoginHelper
	{
		private IDataBaseReader dbr;
		private ISecurityHelper sHelper;

		public LoginHelper()
		{
			this.dbr = new DataBaseReader();
			this.sHelper = new SecurityHelper();
		}

		public IdSession Login(LoginPassword loginPassword)
		{
			string getUser = $"select * from Users where email = '{loginPassword.Email}'";
			User loginUser = dbr.GetFirstOrDefault<User>(getUser);
			if (loginUser == null)
			{
				return null;
			}
			string getPassword = $"select password from Passwords where ownerId = {loginUser.Id}";
			string dbSavedPasswordHash = dbr.GetFirstOrDefault<string>(getPassword);
			if (String.IsNullOrEmpty(dbSavedPasswordHash))
			{
				return null;
			}
			if (sHelper.CheckIfPasswordMatches(dbSavedPasswordHash, loginPassword.Password, 20))
			{
				Guid sessionGuid = sHelper.CreateLoginSession(loginUser.Id);
				IdSession sessionDetails = new IdSession { OwnerId = loginUser.Id, SessionGuid = sessionGuid };
				return sessionDetails;
			}
			else
			{
				return null;
			}
		}
	}
}