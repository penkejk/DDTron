using DudaTronReact.Controllers.Interfaces;
using DudaTronReact.Model;
using DudaTronReact.Model.SupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudaTronReact.Controllers
{
	public class WishReader : IWishReader
	{
		IDataBaseReader dbr;

		public WishReader()
		{
			this.dbr = new DataBaseReader();
		}

		public Wish GetWish(int id)
		{
			string getWish = $"select * from Wishes where id = {id}";
			return dbr.GetFirstOrDefault<Wish>(getWish);
		}
		public IEnumerable<Wish> GetWishesForEvent(Event eventDb)
		{
			string getWishes = $"select * from wishes where eventid = {eventDb.Id}";
			return dbr.GetData<Wish>(getWishes);

		}
		public IEnumerable<Wish> GetWishesForUser(User user) {

			string getWishes = $"select * from wishes where userid = {user.Id}";
			return dbr.GetData<Wish>(getWishes);
		}
		public Wish GetWishForUserAndEvent(UserEventParam param) {
			string getWishes = $"select * from wishes where OwnerId = {param.OwnerId} and eventid = {param.EventId}";
			return dbr.GetSingleOrDefault<Wish>(getWishes);
		}
	}
}
