using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transport.Core.Entities.User;

namespace UnitTests.Core.Entities.User
{
	[TestClass]
	public class AppUserTest
	{
		[TestMethod]
		public void PC_UserNNTest()
		{
			var user = new AppUser();
			Assert.IsNotNull(user);
		}

		[TestMethod]
		public void PC_TRequestsNTest()
		{
			var user = new AppUser();
			Assert.IsNotNull(user.TransportRequests);
		}
	}
}
