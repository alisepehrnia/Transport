using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using X.Core.Constants;
using X.Core.Extensions.AppIdentityExtensions;

namespace X.Infrastructure.Identity
{
	public class AppIdentityDbContextSeed
	{
		/// <summary>
		/// Configures Default & Admin Users And Roles
		/// </summary>
		/// <returns>Array Of IdentityResult's</returns>
		public static async Task<IdentityResult[]> SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			var results = new IdentityResult[2];
			results[0] = await userManager.AddUser(AuthConstants.DemoUsername, AuthConstants.DemoPassword);
			results[1] = await userManager.AddUser(AuthConstants.AdminUsername, AuthConstants.AdminPassword,
				roleManager, AuthConstants.AdminRoleName);

			return results;
		}
	}
}