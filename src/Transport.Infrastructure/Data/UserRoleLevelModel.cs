using Microsoft.AspNet.Identity.EntityFramework;

namespace Transport.Infrastructure.Data
{
	public class UserRoleLevelModel<TUser, TRole, TLevel>
		where TUser : IdentityUser
		where TRole : IdentityRole
		where TLevel : struct
	{
		public TUser User { get; set; }
		public TRole Role { get; set; }
		public TLevel Level { get; set; }
	}
}
