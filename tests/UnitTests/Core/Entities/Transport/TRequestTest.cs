using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transport.Core.Entities.Transport;
using Transport.Core.Entities.User;

namespace UnitTests.Core.Entities.Transport
{
	//ALERT: Not All Of Constructors Tested
	//CAUTION: FC (Full Constructor) Test Is In TRequestChainTest
	[TestClass]
	public class TRequestTest
	{
		[TestMethod]
		public void PC_RequestNNTest()
		{
			var req = new TransportRequest();
			Assert.IsNotNull(req);
		}

		[TestMethod]
		public void PC_DateTimeEqToNowTest()
		{
			var req = new TransportRequest();
			var now = DateTime.Now;
			var reqTime = req.DateTime;
			Assert.IsTrue(reqTime.Subtract(now).TotalMilliseconds < 1000);
		}

		[TestMethod]
		public void C_InitTest()
		{
			var user = new AppUser();
			var travelTime = new DateTime();
			var address = "-";
			var confirm = new TransportRequest(user, travelTime, address);
			Assert.IsTrue(confirm.User == user && confirm.TravelDateTime == travelTime && confirm.Address == address);
		}
	}
}
