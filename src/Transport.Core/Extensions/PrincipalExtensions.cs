using System.Linq;
using System.Security.Principal;
using Transport.Core.Enums;

namespace Transport.Core.Extensions
{
	public static class PrincipalExtensions
	{
		/// <summary>
		/// Checks Wether A Pricincipal Is In Role Or Not
		/// </summary>
		public static bool IsInRole(this IPrincipal principal, UserRoles userRole)
		{
			return principal.IsInRole(userRole.ToString());
		}

		/// <summary>
		/// Checks Wether A Pricincipal Is In Any Of Roles Or Not
		/// </summary>
		public static bool IsInRoles(this IPrincipal principal, params UserRoles[] userRoles)
		{
			return userRoles.Any(ur => principal.IsInRole(ur));
		}
	}
}
