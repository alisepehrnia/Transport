using System.Security.Principal;
using Transport.Core.Constants;
using Transport.Core.Specifications;

namespace Transport.Core.Services
{
	public static class UserPremissionsCheckService
	{
		private static PrincipalByRolesSpec TransportRequestRolesSpec => 
			new PrincipalByRolesSpec(PremissionConstants.TransportRequestRoles);

		private static PrincipalByRolesSpec TransportRequestApproveRolesSpec =>
			new PrincipalByRolesSpec(PremissionConstants.TransportRequestApproveRoles);

		/// <summary>
		/// Check If A Principal Can Send Requests For Transport Or Not
		/// Temporarily Specified By PremissionConstants.TransportRequestRoles
		/// And Through Using PrincipalByRolesSpec (Needs Better Architecture :)
		/// </summary>
		public static bool CanTransportRequest(IPrincipal principal)
		{
			return TransportRequestRolesSpec.IsSatisfiedBy(principal);
		}

		/// <summary>
		/// Check If A Principal Can Approve Transport Requests Or Not
		/// Temporarily Specified By PremissionConstants.TransportRequestApproveRoles
		/// And Through Using PrincipalByRolesSpec (Needs Better Architecture :)
		/// </summary>
		public static bool CanApproveTransportRequest(IPrincipal principal)
		{
			return TransportRequestApproveRolesSpec.IsSatisfiedBy(principal);
		}
	}
}
