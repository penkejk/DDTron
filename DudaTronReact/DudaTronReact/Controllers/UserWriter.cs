using DudaTronReact.Controllers.Interfaces;
using DudaTronReact.Controllers.Security;
using DudaTronReact.Controllers.SupportClasses;
using DudaTronReact.Exceptions;
using DudaTronReact.Model;
using System;

namespace DudaTronReact.Controllers
{
	public class UserWriter : IUserWriter
	{
		private IDataBaseReader dbr;
		private IUserReader userReader;

		public UserWriter()
		{
			this.dbr = new DataBaseReader();
			this.userReader = new UserReader();
		}

		public void CreateUser(UserWithPassword user)
		{
			ValidateCreateUser(user);

			if (userReader.GetUser(user.Email) != null)
			{
				throw new UserAlreadyExistsException("The user already exists");
			}

			user.Password = new SecurityHelper().HashPassword(user.Password, 20);
			string insertUser = "insert into Users (Name, LastName,Email) values (@Name, @LastName,@Email)";
			string insertPassword = $"insert into Passwords (OwnerId, Password) values ((select id from users where email = @Email), @Password)";

			dbr.InsertDataInTransaction(new string[] { insertUser, insertPassword }, user);
		}

		public void DeleteUser(DeleteUserParam userParam)
		{
			string deleteWishes = "delete Wishes where OwnerId = @Id";
			string deleteUser = " delete Users where Id = @Id";
			string deletePassword = "delete Passwords where OwnerId=@Id";
			dbr.DeleteDataInTransaction(new string[] { deleteWishes, deleteUser, deletePassword }, userParam);
		}

		public void UpdateUser(User user)
		{
			string updateUser = "update Users set Name=@Name, LastName=@LastName, Email = @Email where Id = @Id";
			string getUserByNewMail = "select * from Users where Email=@Email";
			if (userReader.GetUser(user.Email) != null)
			{
				throw new UserAlreadyExistsException("The user with this email already exists.");
			}
			dbr.UpdateData(updateUser, user);
		}

		public void UpdatePassword(UserWithPassword user)
		{
			user.Password = new SecurityHelper().HashPassword(user.Password, 20);
			string updatePassword = "update Passwords set password = @Password where OwnerId= @Id";
			dbr.UpdateData(updatePassword, user);
		}

		private void ValidateCreateUser(UserWithPassword user)
		{
			if (String.IsNullOrEmpty(user.Email) || String.IsNullOrEmpty(user.Name) || String.IsNullOrEmpty(user.LastName)
				|| String.IsNullOrEmpty(user.Password))
			{
				throw new IncorrectRequestFormatException("The user data is incomplete");
			}
		}
	}
}