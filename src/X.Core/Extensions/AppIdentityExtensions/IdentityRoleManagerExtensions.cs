using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace X.Core.Extensions.AppIdentityExtensions
{
	public static class IdentityRoleManagerExtensions
	{
		public static async Task<IdentityResult> AddRole(this RoleManager<IdentityRole> @this, string roleName)
		{
			return await @this.CreateAsync(new IdentityRole(roleName));
		}
	}
}
