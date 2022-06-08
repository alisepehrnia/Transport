using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Transport.Infrastructure.Identity
{
	public class ApplicationRole : IdentityRole
	{
		public ApplicationRole()
		{
		}

		public async Task<IdentityResult> GenerateUserRoleAsync(RoleManager<ApplicationRole> manager)
		{
			return await manager.CreateAsync(this);
		}
	}
}