using System.Security.Principal;
using Transport.Core.Constants;
using Transport.Core.Specifications;

namespace Transport.Core.Services
{
	/// <summary>
	/// Helper Methods To Check Whether A User Have Special Premisons Or Not
	/// ALERT: Needs Better Architecture :\ 
	/// </summary>
	public static class UserPremissionsCheckService
	{
		private static PrincipalByRolesSpec TransportRequestRolesSpec => 
			new PrincipalByRolesSpec(PremissionConstants.TRequestRoles);

		private static PrincipalByRolesSpec TransportRequestApproveRolesSpec =>
			new PrincipalByRolesSpec(PremissionConstants.TRequestConfirmRoles);

		/// <summary>
		/// Check If A Principal Can Send Requests For Transport Or Not
		/// Temporarily Specified By PremissionConstants.TransportRequestRoles
		/// And Through Using PrincipalByRolesSpec
		/// </summary>
		public static bool CanTransportRequest(IPrincipal principal)
		{
			return TransportRequestRolesSpec.IsSatisfiedBy(principal);
		}

		/// <summary>
		/// Check If A Principal Can Approve Transport Requests Or Not
		/// Temporarily Specified By PremissionConstants.TransportRequestApproveRoles
		/// And Through Using PrincipalByRolesSpec
		/// </summary>
		public static bool CanApproveTransportRequest(IPrincipal principal)
		{
			return TransportRequestApproveRolesSpec.IsSatisfiedBy(principal);
		}
	}
}
