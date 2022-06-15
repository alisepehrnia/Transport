using System.Linq;
using System.Security.Principal;
using Ardalis.Specification;
using Transport.Core.Enums;
using Transport.Core.Extensions;

namespace Transport.Core.Specifications
{
	/// <summary>
	/// Check User Priniciapl With Roles
	/// </summary>
	public class PrincipalByRolesSpec : Specification<IPrincipal>
	{
		public PrincipalByRolesSpec(params UserRoles[] userRoles)
		{
			Query.Where(u => u.IsInRoles(userRoles));
		}
	}
}
