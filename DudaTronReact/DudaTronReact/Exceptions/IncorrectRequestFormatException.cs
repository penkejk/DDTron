using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudaTronReact.Exceptions
{
	public class IncorrectRequestFormatException :Exception
	{
		public IncorrectRequestFormatException(string message) :base(message)
		{

		}
	}
}
