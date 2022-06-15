using System.Collections.Generic;
using Transport.Core.Enums;
using Transport.Core.Extensions;

namespace Transport.Core.Constants
{
	/// <summary>
	/// Constants Showing Roles And Their Premissions Such as Create Request & Confirm Request
	/// CAUTION: Not Working Directly In Controller Annotations Yet! (Just To Keep In Mind The Roles And Premissions)
	/// </summary>
	public static class PremissionConstants
	{
		/// <summary>
		/// Roles Who Can Create New Users: Admin
		/// </summary>
		public static UserRoles[] TUserCreate => new UserRoles[]
		{
			UserRoles.Admin
		};

		/// <summary>
		/// Roles Who Can Create New Transport Requests: Manager, MiddleManager, Employee
		/// </summary>
		public static UserRoles[] TRequestRoles => new UserRoles[]
		{
			UserRoles.Manager,
			UserRoles.MiddleManager,
			UserRoles.Employee
		};

		/// <summary>
		/// Roles Who Can Confirm Transport Requests: Manager, MiddleManager
		/// </summary>
		public static UserRoles[] TRequestConfirmRoles => new UserRoles[]
		{
			UserRoles.MiddleManager,
			UserRoles.Manager
		};

		//Helpers - Commented Out Because They Are Not Working In It's Place
		//public static IEnumerable<string> TRequestRoleNames = TRequestRoles.GetNames();
		public static IEnumerable<string> TRequestConfirmRoleNames => TRequestConfirmRoles.GetNames();
		//public static IEnumerable<string> TRequestAndConfirmRoleNames = TRequestRoleNames.Union(TRequestConfirmRoleNames);
		//public static string TRequestAndConfirmRoleNamesString = string.Join(",", TRequestAndConfirmRoleNames.ToArray());
	}
}
