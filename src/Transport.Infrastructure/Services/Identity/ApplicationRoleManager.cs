using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Transport.Infrastructure.Identity;

namespace Transport.Infrastructure.Services.Identity
{
	public class ApplicationRoleManager : RoleManager<ApplicationRole>
	{
		public ApplicationRoleManager(IRoleStore<ApplicationRole, string> store) : base(store)
		{
		}

		public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
		{
			var manager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context.Get<AppIdentityDbContext>()));

			return manager;
		}
	}
}
