using System;
using System.Text;
using Microsoft.AspNet.Identity;

namespace Transport.Core.Constants
{
	/// <summary>
	/// Constants Associated With Authentication and Authorization
	/// </summary>
	public static class AuthConstants
	{
		/// <summary>
		/// Default Type Of Authentication
		/// </summary>
		public const string DefaultAuthenticationType = DefaultAuthenticationTypes.ApplicationCookie;

		/// <summary>
		/// Jwt Token Expire Time
		/// </summary>
		public static TimeSpan JWTTokenExpireDuration = new TimeSpan(7, 0, 0, 0); // 7 Days

		/// <summary>
		/// Jwt Token Key String
		/// </summary>
		public const string JWTTokenKeyString = "r4We@g3hfg235Sd2Klq8@kcmwLsSo}q1";

		/// <summary>
		/// Jwt Token Key As byte[]
		/// </summary>
		public static byte[] JWTTokenKey = Encoding.ASCII.GetBytes(JWTTokenKeyString);

		/// <summary>
		/// Account Lockout Mechanism Enable/Disable
		/// </summary>
		public const bool UserLockoutEnabledByDefault = false;

		/// <summary>
		/// Account Lockout Failed Attemps Limit
		/// </summary>
		public const int MaxFailedAccessAttemptsBeforeLockout = 3;

		/// <summary>
		/// Account Lockout Duration
		/// </summary>
		public static TimeSpan DefaultAccountLockoutTimeSpan = new TimeSpan(1, 0, 0); // 1 Hour

		/// <summary>
		/// Validate Interval For OWIN Security Stamp Validator 
		/// </summary>
		public static TimeSpan SecurityStampValidatorValidateInterval => TimeSpan.FromMinutes(30);
	}
}
