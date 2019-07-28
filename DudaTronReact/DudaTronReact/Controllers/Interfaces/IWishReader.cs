using DudaTronReact.Model;
using DudaTronReact.Model.SupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudaTronReact.Controllers.Interfaces
{
	interface IWishReader
	{
		Wish GetWish(int id);
		IEnumerable <Wish> GetWishesForEvent(Event eventDb);
		IEnumerable<Wish> GetWishesForUser(User user);
		Wish GetWishForUserAndEvent(UserEventParam param);

	}
}
