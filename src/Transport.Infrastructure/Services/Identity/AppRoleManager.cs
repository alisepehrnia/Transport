using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Transport.Core.Entities;
using Transport.Infrastructure.Data.DataAccess;

namespace Transport.Infrastructure.Services.Identity
{
	public class AppRoleManager : RoleManager<AppRole>
	{
		public AppRoleManager(IRoleStore<AppRole, string> store) : base(store)
		{
		}

		public static AppRoleManager Create(IdentityFactoryOptions<AppRoleManager> options, IOwinContext context)
		{
			var manager = new AppRoleManager(new RoleStore<AppRole>(context.Get<AppIdentityDbContext>()));

			return manager;
		}
	}
}
