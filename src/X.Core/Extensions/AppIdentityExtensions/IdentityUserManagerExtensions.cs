using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace X.Core.Extensions.AppIdentityExtensions
{
	public static class IdentityUserManagerExtensions
	{
		/// <summary>
		/// Creates New User And Adds It To UserManager
		/// </summary>
		/// <returns>Task Result</returns>
		public static async Task<IdentityResult> AddUser<T>(this UserManager<T> @this, string username, string password) where T : IdentityUser
		{
			var defaultUser = new IdentityUser { UserName = username };
			return await @this.CreateAsync((T)defaultUser, password);
		}

		/// <summary>
		/// Creates New User, Adds It To UserManager And Assign Role To It If Successfully Created
		/// </summary>
		/// <returns>Task Result (AddUser Result Or AddToRoleAsync Result</returns>
		public static async Task<IdentityResult> AddUser<T>(this UserManager<T> @this, string username, string password, string roleName)
			where T : IdentityUser
		{
			var addResult = await @this.AddUser(username, password);
			if (!addResult.Succeeded) return addResult;

			var user = await @this.FindByNameAsync(username);
			return await @this.AddToRoleAsync(user.Id, roleName);
		}

		/// <summary>
		/// Creates New User, Adds It To UserManager Then If Succeed Create Role In RoleManager Then If Succeed Assign It To Created User
		/// </summary>
		/// <returns>Task Result (AddUser Result Or RoleManager.CreateAsync Result Or AddToRoleAsync Result</returns>
		public static async Task<IdentityResult> AddUser<T>(this UserManager<T> @this, string username, string password,
			RoleManager<IdentityRole> roleManager, string roleName) where T : IdentityUser
		{
			var addResult = await @this.AddUser(username, password);
			if (!addResult.Succeeded) return addResult;

			var addRoleResult = await roleManager.AddRole(roleName);
			if (!addRoleResult.Succeeded) return addRoleResult;

			var user = await @this.FindByNameAsync(username);
			return await @this.AddToRoleAsync(user.Id, roleName);
		}
	}
}
