using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudaTronReact.Exceptions
{
	public class SessionExpiredException:Exception
	{
		public SessionExpiredException(string message):base(message)
		{

		}
	}
}
