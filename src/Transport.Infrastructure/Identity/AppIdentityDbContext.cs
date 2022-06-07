using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Transport.Infrastructure.Identity
{
	public class AppIdentityDbContext : IdentityDbContext<ApplicationUser>
	{
		public AppIdentityDbContext() : base("name=TransportIdentityConnectionString", throwIfV1Schema: false)
		{
		}

		protected override void OnModelCreating(DbModelBuilder builder)
		{
			base.OnModelCreating(builder);
			// Customize the ASP.NET Identity model and override the defaults if needed.
			// For example, you can rename the ASP.NET Identity table names and more.
			// Add your customizations after calling base.OnModelCreating(builder);
		}

		public static AppIdentityDbContext Create()
		{
			return new AppIdentityDbContext();
		}
	}
}