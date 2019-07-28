using DudaTronReact.Controllers.SupportClasses;
using DudaTronReact.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudaTronReact.Controllers.Interfaces
{
	public interface IUserWriter
	{
		void CreateUser(UserWithPassword user);
		void DeleteUser(DeleteUserParam user);
		void UpdateUser(User user);
		void UpdatePassword(UserWithPassword user);
	}
}
