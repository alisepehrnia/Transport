using System;
using System.Text;

namespace X.Core.Constants
{
	static public class AuthConstants
	{
		public const string DemoUsername = "demo";
		public const string DemoPassword = "demo";

		public const string AdminUsername = "admin";
		public const string AdminPassword = "admin";

		public const string AdminRoleName = "ADMIN";

		public static TimeSpan JWTTokenExpireDuration = new TimeSpan(7, 0, 0, 0); // 7 Days
		public const string JWTTokenKeyString = "r4We@g3hfg235Sd2Klq8@kcmwLsSo}q1";
		public static byte[] JWTTokenKey = Encoding.ASCII.GetBytes(JWTTokenKeyString);
	}
}
