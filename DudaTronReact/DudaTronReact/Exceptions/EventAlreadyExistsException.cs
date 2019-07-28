using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudaTronReact.Exceptions
{
	public class EventAlreadyExistsException:Exception
	{
		public EventAlreadyExistsException(string message):base(message)
		{

		}
	}
}
