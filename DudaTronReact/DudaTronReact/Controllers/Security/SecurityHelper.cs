using DudaTronReact.Controllers.Interfaces;
using DudaTronReact.Controllers.Security.Interfaces;
using DudaTronReact.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Cryptography;

namespace DudaTronReact.Controllers.Security
{
	public class SecurityHelper : ISecurityHelper
	{
		private IDataBaseReader dbr;

		public SecurityHelper()
		{
			this.dbr = new DataBaseReader();
		}

		private byte[] CreateSalt(int saltLength)
		{
			byte[] bytes = new byte[saltLength];
			using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
			{
				rngCsp.GetBytes(bytes);
			}
			return bytes;
		}

		public string HashPassword(string password, int saltLength)
		{
			byte[] salt = CreateSalt(saltLength);
			byte[] hash = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256).GetBytes(100 + saltLength);

			byte[] hashBytes = new byte[100 + saltLength];
			Array.Copy(salt, 0, hashBytes, 0, saltLength);
			Array.Copy(hash, 0, hashBytes, saltLength, 100);
			return Convert.ToBase64String(hashBytes);
		}

		public bool CheckIfPasswordMatches(string hashedPassword, string newPassword, int saltLength)
		{
			byte[] hashedPasswordBytes = Convert.FromBase64String(hashedPassword);
			byte[] saltBytesFromPassword = new byte[saltLength];
			Array.Copy(hashedPasswordBytes, 0, saltBytesFromPassword, 0, saltLength);
			var pbkdf2 = new Rfc2898DeriveBytes(newPassword, saltBytesFromPassword, 10000, HashAlgorithmName.SHA256);
			byte[] newHash = pbkdf2.GetBytes(100 + saltLength);
			for (int i = 0; i < 100; i++)
				if (hashedPasswordBytes[i + saltLength] != newHash[i])
					return false;

			return true;
		}

		public Guid CreateLoginSession(int userId)
		{
			Guid sessionGuid = Guid.NewGuid();
			DateTime expireDate = DateTime.UtcNow.AddHours(2);

			Session newSession = new Session
			{
				OwnerId = userId,
				SessionGuid = sessionGuid,
				ValidTo = expireDate
			};

			string checkSession = $"select * from Sessions where OwnerId = {newSession.OwnerId}";

			Session existingSession = dbr.GetFirstOrDefault<Session>(checkSession);
			if (existingSession == null)
			{
				CreateSession(newSession);
				return newSession.SessionGuid;
			}
			else
			{
				ProlongSession(existingSession);
				return existingSession.SessionGuid;
			}
		}

		private void CreateSession(Session session)
		{
			string insertSession = "insert into Sessions (OwnerId,SessionGuid,ValidTo) values (@OwnerId,@SessionGuid,@ValidTo)";
			dbr.InsertData(insertSession, session);
		}

		public void ProlongSession(Session session)
		{
			session.ValidTo = DateTime.UtcNow.AddHours(1);
			string updateSession = "update Sessions set ValidTo =@ValidTo where OwnerId = @OwnerId";
			dbr.UpdateData(updateSession, session);
		}

		public bool GetCurrentSessionState(IdSession currentSessionInfo)
		{
			string checkSession = $"select * from Sessions where  OwnerId = {currentSessionInfo.OwnerId}";
			Session existingSession = dbr.GetFirstOrDefault<Session>(checkSession);
			if (existingSession == null)
			{
				return false;
			}
			else if (existingSession.ValidTo < DateTime.UtcNow || existingSession.SessionGuid != currentSessionInfo.SessionGuid)
			{
				KillSessionForUserId(currentSessionInfo.OwnerId);
				return false;
			}
			else
			{
				return true;
			}
		}

		public void KillSessionForUserId(int userId)
		{
			string deleteSession = $"Delete Sessions where OwnerId={userId}";
			dbr.DeteleData(deleteSession);
		}

		private bool ValdidateSessionContext(HttpContext httpContext)
		{
			string contextUser = httpContext.Request.Headers["UserId"];
			string contextSessionGuid = httpContext.Request.Headers["SessionGuid"];
			if (string.IsNullOrEmpty(contextSessionGuid) || string.IsNullOrEmpty(contextUser))
			{
				return false;
			}

			IdSession idSession = new IdSession
			{
				OwnerId = Convert.ToInt32(contextUser),
				SessionGuid = new Guid(contextSessionGuid)
			};

			return GetCurrentSessionState(idSession);
		}

		public void ValidateRequest(HttpContext context)
		{
			if (!ValdidateSessionContext(context))
			{
				throw new SessionExpiredException("Your session is expired.");
			}
		}
	}
}