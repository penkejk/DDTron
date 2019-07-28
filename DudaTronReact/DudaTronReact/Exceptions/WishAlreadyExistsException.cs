using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudaTronReact.Exceptions
{
	public class WishAlreadyExistsException:Exception
	{
		public WishAlreadyExistsException(string message) : base(message)
		{

		}
	}
}
