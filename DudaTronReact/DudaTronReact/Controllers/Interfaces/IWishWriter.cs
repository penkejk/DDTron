using DudaTronReact.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudaTronReact.Controllers.Interfaces
{
	public interface IWishWriter
	{
		void CreateWish(Wish wish );
		void DeleteWish(Wish wish);
		void DeleteWish(int wishId);
		void DeleteWishesForAUser(User user);
		void UpdateWish(Wish wish);
	}
}
 