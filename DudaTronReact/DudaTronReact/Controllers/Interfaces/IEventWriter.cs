using DudaTronReact.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudaTronReact.Controllers.Interfaces
{
	interface IEventWriter
	{
		void CreateEvent(Event eventdb);
		void UpdateEvent(Event eventdb);
		void DeleteEvent(Event eventdb);
	}
}
