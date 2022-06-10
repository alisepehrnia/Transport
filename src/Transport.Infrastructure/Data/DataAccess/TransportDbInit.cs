using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Transport.Core.Enums;
using Transport.Core.Extensions;
using Transport.Core.Extensions.AppIdentityExtensions;
using Transport.Core.Entities.User;

namespace Transport.Infrastructure.Data.DataAccess
{
	/// <summary>
	/// Add Default Users & Roles. Disabled (To Enable Put Codes On 
	/// static TransportDbContext() Out Of Comment)
	/// </summary>
	public class TransportDbInit : DropCreateDatabaseIfModelChanges<TransportDbContext>
	{
		protected override void Seed(TransportDbContext context)
		{
			InitializeIdentity(context);
			base.Seed(context);
		}

		public static void InitializeIdentity(TransportDbContext db)
		{
			var userManager = new UserManager<AppUser>(new UserStore<AppUser>(db));
			var roleManager = new RoleManager<AppRole>(new RoleStore<AppRole>(db));

			foreach (var role in EnumExtensions.ToDictionary<UserRoles>())
			{
				var username = role.Value.ToLower();
				_ = userManager.AddUser(username, username, roleManager, role.Value, role.Key).Result;
			}
		}
	}
}