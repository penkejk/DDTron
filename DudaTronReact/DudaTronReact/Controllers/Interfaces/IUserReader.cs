using DudaTronReact.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudaTronReact.Controllers.Interfaces
{
	public interface IUserReader
	{
		User GetUser(string email);
		User GetUser(int id);
	}
}
