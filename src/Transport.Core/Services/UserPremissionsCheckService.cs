using System.Security.Principal;
using Transport.Core.Constants;
using Transport.Core.Specifications;

namespace Transport.Core.Services
{
	public static class UserPremissionsCheckService
	{
		private static PrincipalByRolesSpec TransportRequestRolesSpec => 
			new PrincipalByRolesSpec(PremissionConstants.TransportRequestRoles);

		/// <summary>
		/// Check If A Principal Can Send Requests For Transport Or Not
		/// Temporarily Specified By PremissionConstants.TransportRequestRoles
		/// And Through Using PrincipalByRolesSpec (Needs Better Architecture :)
		/// </summary>
		/// <param name="principal"></param>
		/// <returns></returns>
		public static bool CanTransportRequest(IPrincipal principal)
		{
			return TransportRequestRolesSpec.IsSatisfiedBy(principal);
		}
	}
}
