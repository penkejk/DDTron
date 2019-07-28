using System;
using System.Collections.Generic;
using System.Text;
using DudaTronReact.Controllers.Security;
using DudaTronReact.Controllers.Security.Interfaces;
using NUnit.Framework;


namespace Tests
{
	[TestFixture]
	class SecurityHelperTests
	{
		ISecurityHelper secHelper;

		[SetUp]
		public void Setup()
		{
			secHelper = new SecurityHelper();
		}

		[TestCase(20)]
		[TestCase(200)]
		[TestCase(8)]
		[TestCase(10)]
		public void DecodingTest(int saltLenght)
		{
			string password = "PasswordToCheckFor55";
			string hashedStuff = secHelper.HashPassword(password,saltLenght);
			var match = secHelper.CheckIfPasswordMatches(hashedStuff, password,saltLenght);
			Assert.IsTrue(match);
		}

		[TestCase("passwordToCheckFor55")]
		[TestCase(" PasswordToCheckFor55")]
		[TestCase("PasswordToCheckFor55 ")]
		[TestCase("PasswordToCheckFar55")]
		public void DecodingTestNotMatchingPasswords(string newPassword)
		{
			string password = "PasswordToCheckFor55";
			string hashedStuff = secHelper.HashPassword(password, 55);
			var match = secHelper.CheckIfPasswordMatches(hashedStuff, newPassword, 55);
			Assert.IsFalse(match);
		}

		[Test]
		public void SessionStateTest()
		{
			IdSession sessionInfo = new IdSession { OwnerId = 9, SessionGuid = new Guid("44AF59D0-2E73-4A1C-8CF9-DA8D2B28EFAF")};

			Assert.IsTrue(	secHelper.GetCurrentSessionState(sessionInfo));

		}

	}
}
