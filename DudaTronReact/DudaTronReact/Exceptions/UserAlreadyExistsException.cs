﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudaTronReact.Exceptions
{
	public class UserAlreadyExistsException:Exception
	{
		public UserAlreadyExistsException(string message):base(message)
		{

		}
	}
}
