using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudaTronReact.Controllers.Security
{
	public class IdSession
	{
		public int OwnerId { get; set; }
		public Guid SessionGuid { get; set; }
	}
}
