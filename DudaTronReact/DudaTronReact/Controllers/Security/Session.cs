using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudaTronReact.Controllers.Security
{
	public class Session
	{
		public int OwnerId { get; set; }
		public Guid SessionGuid { get; set; }
		public DateTime ValidTo { get; set; }

	}
}
