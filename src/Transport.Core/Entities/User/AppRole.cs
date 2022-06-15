using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Transport.Core.Entities.User
{
	/// <summary>
	/// Based On Identity Role With New Properties: Role Level
	/// </summary>
	public class AppRole : IdentityRole
	{
		public AppRole() : base()
		{
		}

		public AppRole(string name) : base(name)
		{
		}

		public AppRole(string name, int level) : base(name)
		{
			Level = level;
		}

		public async Task<IdentityResult> GenerateUserRoleAsync(RoleManager<AppRole> manager)
		{
			return await manager.CreateAsync(this);
		}

		/// <summary>
		/// Level Of Role (Used For Hierarchical Request Approval)
		/// </summary>
		public virtual int Level { get; set; }
	}
}