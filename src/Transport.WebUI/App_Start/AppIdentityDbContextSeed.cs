using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Transport.Core.Enums;
using Transport.Core.Extensions;
using Transport.Core.Extensions.AppIdentityExtensions;
using Transport.Infrastructure.Services.Identity;

namespace Trasnsport.WebUI.App_Start
{
	public class AppIdentityDbContextSeed
	{
		/// <summary>
		/// Add Default Users & Roles
		/// </summary>
		public static async Task Init()
		{
			var userManager = HttpContext.Current.GetOwinContext()
				.GetUserManager<AppUserManager>();

			var roleManager = HttpContext.Current.GetOwinContext()
				.Get<AppRoleManager>();

			foreach (var role in EnumExtensions.ToDictionary<UserRoles>())
			{
				var username = role.Value.ToLower();
				await userManager.AddUser(username, username, roleManager, role.Value, role.Key);
			}
		}
	}
}