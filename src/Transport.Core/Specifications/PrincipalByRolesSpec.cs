using System.Linq;
using System.Security.Principal;
using Ardalis.Specification;
using Transport.Core.Constants;
using Transport.Core.Enums;
using Transport.Core.Extensions;

namespace Transport.Core.Specifications
{
	public class PrincipalByRolesSpec : Specification<IPrincipal>
	{
		public PrincipalByRolesSpec(params UserRoles[] userRoles)
		{
			Query.Where(u => u.IsInRoles(userRoles));
		}

		public static PrincipalByRolesSpec TransportRequestRolesSpec()
			=> new PrincipalByRolesSpec(PremissionConstants.TransportRequestRoles);
	}
}
