using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Transport.Core.Entities.User
{
	public class AppRole : IdentityRole
	{
		public AppRole()
		{
		}

		public async Task<IdentityResult> GenerateUserRoleAsync(RoleManager<AppRole> manager)
		{
			return await manager.CreateAsync(this);
		}

		/// <summary>
		/// Level Of User (Used For Hierarchical Request Approval)
		/// </summary>
		public int Level { get; set; }
	}
}