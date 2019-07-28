using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DudaTronReact.Controllers.Security.Interfaces;
using DudaTronReact.Controllers.Security;
using DudaTronReact.Controllers.Secutity;

namespace Tests
{
	class LoginHelperTests
	{

		ILoginHelper loginHelper;

		[SetUp]
		public void Setup()
		{
			loginHelper = new LoginHelper();
		}

		[Test]
		public void ValidLogin()
		{
			LoginPassword loginPassword = new LoginPassword
			{
				Email= "psikutas2@one.pl",
				Password = "somePassword"
			};
			Assert.AreEqual(9, loginHelper.Login(loginPassword));
		}

		[Test]
		public void InValidLogin()
		{
			LoginPassword loginPassword = new LoginPassword
			{
				Email = "psikutas2@one.pll",
				Password = "somePassword"
			};
			Assert.AreEqual(0, loginHelper.Login(loginPassword));
		}

		[Test]
		public void InValidPassword()
		{
			LoginPassword loginPassword = new LoginPassword
			{
				Email = "psikutas2@one.pll",
				Password = "somePassworD"
			};
			Assert.AreEqual(0, loginHelper.Login(loginPassword));
		}


	}
}
