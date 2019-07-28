using DudaTronReact.Controllers.Interfaces;
using DudaTronReact.Exceptions;
using DudaTronReact.Model;
using DudaTronReact.Model.SupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudaTronReact.Controllers
{
	public class WishWriter : IWishWriter
	{

		IDataBaseReader dbr;
		IWishReader wReader;

		public WishWriter()
		{
			this.dbr = new DataBaseReader();
			this.wReader = new WishReader();

		}

		public void CreateWish(Wish wish)
		{
			if (wish.EventId == null || wish.OwnerId == null)
			{
				throw new IncorrectRequestFormatException("Event or user do not exist");
			}

			ValidateDuplicatedWish(wish);

			string insertWish = "insert into Wishes (Text,OwnerId,EventId) values (@Text,@OwnerId,@EventId)";
			dbr.InsertData(insertWish, wish);
		}
		public void DeleteWish(Wish wish)
		{
			string deleteWish = "Delete Wishes where Id = @Id";
			dbr.DeteleData(deleteWish, wish);
		}

		public void DeleteWish(int wishId)
		{
			Wish tempWish = new Wish { Id = wishId };
			string deleteWish = "Delete Wishes where Id = @Id";
			dbr.DeteleData(deleteWish, tempWish);
		}

		public void DeleteWishesForAUser(User user)
		{
			string deleteWish = $"Delete Wishes where OwnerId = @Id";
			dbr.DeteleData(deleteWish, user);
		}

		public void UpdateWish(Wish wish)
		{
			if (wish.Id != null && wish.OwnerId != null && wish.EventId != null && !String.IsNullOrEmpty(wish.Text))
			{
				string updateWish = "Update Wishes set Text = @Text where Id = @Id";
				dbr.UpdateData(updateWish, wish);
			}
			else
			{
				throw new IncorrectRequestFormatException("One of the fields is not correct)");
			}
		}

		private void ValidateDuplicatedWish(Wish wish)
		{
			UserEventParam checkExistingParam = new UserEventParam { EventId = (int)wish.EventId, OwnerId = (int)wish.OwnerId };

			if (wReader.GetWishForUserAndEvent(checkExistingParam) != null)
			{
				throw new WishAlreadyExistsException("A wish for this user and event already exists.");
			}
		}

	}
}
