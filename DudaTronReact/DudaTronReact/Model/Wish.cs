using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudaTronReact.Model
{
	public class Wish
	{
		public int? Id { get; set; }
		public string Text { get; set; }
		public int? OwnerId { get; set; }
		public int? EventId { get; set; } 
	}
}
