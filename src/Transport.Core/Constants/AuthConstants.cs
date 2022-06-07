using System;
using System.Text;

namespace Transport.Core.Constants
{
	static public class AuthConstants
	{
		public const string DemoUsername = "demo";
		public const string DemoPassword = "demo";

		public const string AdminUsername = "admin";
		public const string AdminPassword = "admin";

		public static string AdminRoleName = Enums.UserRoles.Admin.ToString();

		public static TimeSpan JWTTokenExpireDuration = new TimeSpan(7, 0, 0, 0); // 7 Days
		public const string JWTTokenKeyString = "r4We@g3hfg235Sd2Klq8@kcmwLsSo}q1";
		public static byte[] JWTTokenKey = Encoding.ASCII.GetBytes(JWTTokenKeyString);

		public static bool UserLockoutEnabledByDefault = true;
		public static int MaxFailedAccessAttemptsBeforeLockout = 3;
		public static TimeSpan DefaultAccountLockoutTimeSpan = new TimeSpan(1, 0, 0);
	}
}
