using System;
using System.Text;

namespace Transport.Core.Constants
{
	public static class AuthConstants
	{
		public static TimeSpan JWTTokenExpireDuration = new TimeSpan(7, 0, 0, 0); // 7 Days
		public const string JWTTokenKeyString = "r4We@g3hfg235Sd2Klq8@kcmwLsSo}q1";
		public static byte[] JWTTokenKey = Encoding.ASCII.GetBytes(JWTTokenKeyString);

		public static bool UserLockoutEnabledByDefault = true;
		public static int MaxFailedAccessAttemptsBeforeLockout = 3;
		public static TimeSpan DefaultAccountLockoutTimeSpan = new TimeSpan(1, 0, 0);
	}
}
