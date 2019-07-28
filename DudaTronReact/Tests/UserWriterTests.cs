using DudaTronReact.Controllers;
using DudaTronReact.Controllers.Interfaces;
using DudaTronReact.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
	[TestFixture]
	class UserWriterTests
	{
		IUserWriter writer;

		[SetUp]
		public void Setup()
		{
	
		}

		[Test]
		public void CreateUserTest()
		{
			UserWithPassword user = new UserWithPassword
			{
				Email = Guid.NewGuid().ToString() + "Onet.pl",
				LastName = Guid.NewGuid().ToString(),
				Name = Guid.NewGuid().ToString(),
				Password = "RandomPassword"
			};
			writer = new UserWriter();
			writer.CreateUser(user);

		}

	}
}
