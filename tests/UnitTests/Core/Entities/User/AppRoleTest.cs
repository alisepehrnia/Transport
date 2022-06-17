using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transport.Core.Entities.User;

namespace UnitTests.Core.Entities.User
{
	[TestClass]
	public class AppRoleTest
	{
		[TestMethod]
		public void PC_RoleNNTest()
		{
			var role = new AppRole();
			Assert.IsNotNull(role);
		}

		[TestMethod]
		public void C_InitTest()
		{
			var name = "Admin";
			var role = new AppRole(name);
			Assert.IsTrue(role.Name == name);
		}

		[TestMethod]
		public void FC_InitTest()
		{
			var name = "Admin";
			var level = 10;
			var role = new AppRole(name, level);
			Assert.IsTrue(role.Name == name && role.Level == level);
		}
	}
}
