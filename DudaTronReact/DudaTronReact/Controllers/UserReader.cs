using DudaTronReact.Controllers.Interfaces;
using DudaTronReact.Model;

namespace DudaTronReact.Controllers
{
	public class UserReader : IUserReader
	{
		private IDataBaseReader reader;

		public UserReader(string email)
		{
			this.reader = new DataBaseReader();
		}

		public UserReader()
		{
			this.reader = new DataBaseReader();
		}

		public User GetUser(string email)
		{
			return reader.GetFirstOrDefault<User>($"select * from Users where Email ='{email}'");
		}

		public User GetUser(int id)
		{
			return reader.GetFirstOrDefault<User>($"select * from Users where Id ={id}");
		}
	}
}