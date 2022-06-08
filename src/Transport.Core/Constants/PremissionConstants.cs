using Transport.Core.Enums;

namespace Transport.Core.Constants
{
	public static class PremissionConstants
	{
		public static UserRoles[] TransportRequestRoles => new UserRoles[]
		{
			UserRoles.Employee
		};

		public static UserRoles[] TransportRequestApproveRoles => new UserRoles[]
		{
			UserRoles.MiddleManager,
			UserRoles.Manager
		};
	}
}
