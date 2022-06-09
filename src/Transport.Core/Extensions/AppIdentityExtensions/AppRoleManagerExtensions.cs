using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Transport.Core.Entities.User;

namespace Transport.Core.Extensions.AppIdentityExtensions
{
	public static class AppRoleManagerExtensions
	{
		public static async Task<IdentityResult> AddRole(this RoleManager<AppRole> @this, string roleName, int level)
		{
			return await @this.CreateAsync(new AppRole { Name = roleName, Level = level });
		}
	}
}
