using Microsoft.AspNet.Identity.EntityFramework;
using Transport.Core.Entities.User;

namespace Transport.Infrastructure.Data
{
	public class AppUserRoleLevelModel : UserRoleLevelModel<AppUser, IdentityRole, int>
	{
	}
}
