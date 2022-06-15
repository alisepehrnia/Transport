using System;
using System.Security.Principal;
using Transport.Core.Constants;
using Transport.Core.Enums;
using Transport.Core.Specifications;

namespace Transport.Core.Services
{
	/// <summary>
	/// Helper Methods To Check Whether A User Have Special Premisons Or Not
	/// ALERT: Needs Better Architecture :\ 
	/// </summary>
	public static class UserPremissionsCheckService
	{
		/// <summary>
		/// Check If A Principal Can Do Specified AppTasks
		/// </summary>
		public static bool HavePremission(this IPrincipal principal, AppTasks appTask)
		{
			if (!PremissionConstants.TaskRoles.ContainsKey(appTask))
			{
				throw new NotSupportedException();
			}

			var specification = new PrincipalByRolesSpec(PremissionConstants.TaskRoles[appTask].ToArray());
			return specification.IsSatisfiedBy(principal);
		}
	}
}
