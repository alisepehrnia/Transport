using System;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Transport.Core.Extensions.AppIdentityExtensions;
using Transport.Infrastructure.Identity;
using Transport.Infrastructure.Services.Identity;

namespace Trasnsport.WebUI.App_Start
{
	public class AppIdentityDbContextSeed
	{
		const string emailFormat = "{0}@t";
		const string passwordFormat = "{0}";

		private static string FormatEmail(string name) => string.Format(emailFormat, name);
		private static string FormatPassword(string name) => string.Format(passwordFormat, name);

		/// <summary>
		/// Add Default Users & Roles
		/// </summary>
		public static async Task Init()
		{
			var userManager = HttpContext.Current.GetOwinContext()
				.GetUserManager<ApplicationUserManager>();

			var roleManager = HttpContext.Current.GetOwinContext()
				.Get<ApplicationRoleManager>();

			foreach (var roleName in Enum.GetNames(typeof(ApplicationRole)))
			{
				await roleManager.CreateAsync(new ApplicationRole() { Name = roleName });
				await userManager.AddUser(FormatEmail(roleName), FormatPassword(roleName), roleName);
			}
		}
	}
}