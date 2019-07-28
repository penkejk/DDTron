using NUnit.Framework;
using DudaTronReact.Controllers;
using DudaTronReact.Controllers.Interfaces;
using DudaTronReact.Model;
using System.Collections.Generic;
using System;

namespace Tests
{
	[TestFixture]
	public class DbConnectionTests
	{
		IDataBaseReader dbr;

		[SetUp]
		public void Setup()
		{
			dbr = new DataBaseReader();
		}

		[Test]
		public void ConnectionTest()
		{
			dbr.GetData<object>("select * from users");
		}

		[Test]
		public void GetDataTest()
		{
			List<User> usersOnDb = dbr.GetData<User>("select * from users");
			Assert.IsTrue(usersOnDb.Count > 0);
		}

		[Test]
		public void GetFirstDataTest()
		{
			User usersOnDb = dbr.GetFirst<User>("select * from users");
			Assert.NotNull(usersOnDb);
		}

		[Test]
		public void GetFirstOrDefaultDataTest()
		{
			User usersOnDb = dbr.GetFirst<User>("select * from users");
			Assert.NotNull(usersOnDb);
		}



		[Test]
		public void GetSingleOrDefaultDataTest()
		{
			User usersOnDb = dbr.GetSingleOrDefault<User>("select top 1 * from users");
			Assert.NotNull(usersOnDb);
		}

		[Test]
		public void GetSingleOrDefaultData_Fail_Test()
		{
			User usersOnDb=null;
			Assert.Throws<InvalidOperationException>(()=> usersOnDb =dbr.GetSingleOrDefault<User>("select  * from users"));
			Assert.IsNull(usersOnDb);
		}


		[Test]
		public void InsertDataTest()
		{

			User testUser = new User { Email = Guid.NewGuid().ToString()+"mail.wp.pl",
			LastName = Guid.NewGuid().ToString(),
			Name = Guid.NewGuid().ToString()
			};
			string insertQuery = "insert into Users (Name, LastName, Email) values (@Name, @LastName,@Email)";

			dbr.InsertData(insertQuery, testUser);

			List<User> usersOnDb = dbr.GetData<User>($"select * from users where LastName ='{testUser.LastName}'");
			Assert.AreEqual(1, usersOnDb.Count);
		}


		[Test]
		public void Insert2DataRecordsTest()
		{

			User testUser = new User
			{
				Email = Guid.NewGuid().ToString() + "mail.wp.pl",
				LastName = Guid.NewGuid().ToString(),
				Name = Guid.NewGuid().ToString()
			};
			User testUser2 = new User
			{
				Email = Guid.NewGuid().ToString() + "mail.wp.pl",
				LastName = Guid.NewGuid().ToString(),
				Name = Guid.NewGuid().ToString()
			};
			string insertQuery = "insert into Users (Name, LastName, Email) values (@Name, @LastName,@Email)";

			dbr.InsertData(insertQuery, new User[]{testUser, testUser2 });

			List<User> usersOnDb = dbr.GetData<User>($"select * from users where LastName in ( '{testUser.LastName}','{testUser2.LastName}')");
			Assert.AreEqual(2, usersOnDb.Count);
		}

		[Test]
		public void UpdateDataTest()
		{
			List<User> usersOnDb = dbr.GetData<User>("select top 1 * from users");
			Assert.IsTrue(usersOnDb[0].Id>0);
			string newName = Guid.NewGuid().ToString();
			string updateQuery = $"Update Users set name = '{newName}' where id = @Id";

			dbr.UpdateData(updateQuery, usersOnDb[0]);

			List<User> usersOnDbAter = dbr.GetData<User>($"select * from users where name = '{newName}'");
			Assert.IsTrue(usersOnDbAter.Count== 1);


		}


		[Test]
		public void DeleteDataTest()
		{
			List<User> usersOnDb = dbr.GetData<User>("select top 1 * from users");
			Assert.IsTrue(usersOnDb[0].Id > 0);
	     	string deleteQuery = "Delete Users where Id = @Id";

			dbr.DeteleData(deleteQuery, usersOnDb[0]);

			List<User> usersOnDbAter = dbr.GetData<User>($"select * from users where Id = '{usersOnDb[0].Id}'");
			Assert.IsTrue(usersOnDbAter.Count == 0);
			
		}

	}
}
