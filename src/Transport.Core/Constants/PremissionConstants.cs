using Transport.Core.Enums;

namespace Transport.Core.Constants
{
	public static class PremissionConstants
	{
		/// <summary>
		/// Roles Who Can Create New Transport Requests
		/// </summary>
		public static UserRoles[] TRequestRoles => new UserRoles[]
		{
			UserRoles.Employee
		};

		/// <summary>
		/// Roles Who Can Confirm Transport Requests
		/// </summary>
		public static UserRoles[] TRequestConfirmRoles => new UserRoles[]
		{
			UserRoles.MiddleManager,
			UserRoles.Manager
		};

		//Helpers - Commented Out Because They Are Not Working In It's Place
		//public static IEnumerable<string> TRequestRoleNames = TRequestRoles.GetNames();
		//public static IEnumerable<string> TRequestConfirmRoleNames = TRequestConfirmRoles.GetNames();
		//public static IEnumerable<string> TRequestAndConfirmRoleNames = TRequestRoleNames.Union(TRequestConfirmRoleNames);
		//public static string TRequestAndConfirmRoleNamesString = string.Join(",", TRequestAndConfirmRoleNames.ToArray());
	}
}
