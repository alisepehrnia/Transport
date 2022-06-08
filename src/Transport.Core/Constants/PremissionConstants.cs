using Transport.Core.Enums;

namespace Transport.Core.Constants
{
	public static class PremissionConstants
	{
		public static UserRoles[] TransportRequestRoles = new UserRoles[]
		{
			UserRoles.Manager,
			UserRoles.MiddleManager,
			UserRoles.Employee
		};
	}
}
