using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Transport.Core.Entities.User;

namespace Transport.Core.Extensions.AppIdentityExtensions
{
	public static class AppUserManagerExtensions
	{
		/// <summary>
		/// Creates New User And Adds It To UserManager
		/// </summary>
		/// <returns>Task Result</returns>
		public static async Task<IdentityResult> AddUser(this UserManager<AppUser, string> userManager, string username, string password)
		{
			var user = new AppUser { UserName = username };
			return await userManager.CreateAsync(user, password);
		}

		/// <summary>
		/// Creates New User, Adds It To UserManager And Assign Role To It If Successfully Created
		/// </summary>
		/// <returns>Task Result (AddUser Result Or AddToRoleAsync Result)</returns>
		public static async Task<IdentityResult> AddUser(this UserManager<AppUser, string> userManager, string username, string password, string roleName)
		{
			var user = await userManager.FindByNameAsync(username);
			if (user == null)
			{
				var addResult = await userManager.AddUser(username, password);
				if (!addResult.Succeeded) return addResult;
			}

			if (user == null) user = await userManager.FindByNameAsync(username);
			return await userManager.AddToRoleAsync(user.Id, roleName);
		}

		/// <summary>
		/// Creates New User, Adds It To UserManager Then If Succeed Create Role In RoleManager Then If Succeed Assign It To Created User
		/// </summary>
		/// <returns>Task Result (AddUser Result Or RoleManager.CreateAsync Result Or AddToRoleAsync Result</returns>
		public static async Task<IdentityResult> AddUser(this UserManager<AppUser, string> userManager, string username, string password,
			RoleManager<AppRole> roleManager, string roleName, int roleLevel)
		{
			var user = await userManager.FindByNameAsync(username);
			if (user == null)
			{
				var addResult = await userManager.AddUser(username, password);
				if (!addResult.Succeeded) return addResult;
			}

			var roleExists = await roleManager.RoleExistsAsync(roleName);
			if (!roleExists)
			{
				var addRoleResult = await roleManager.AddRole(roleName, roleLevel);
				if (!addRoleResult.Succeeded) return addRoleResult;
			}

			if(user == null) user = await userManager.FindByNameAsync(username);
			return await userManager.AddToRoleAsync(user.Id, roleName);
		}
	}
}
