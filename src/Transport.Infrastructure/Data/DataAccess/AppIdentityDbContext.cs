using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Transport.Core.Entities;

namespace Transport.Infrastructure.Data.DataAccess
{
	public class AppIdentityDbContext : IdentityDbContext<AppUser>
	{
		public AppIdentityDbContext() : base("name=TransportConnectionString", throwIfV1Schema: false)
		{
		}

		protected override void OnModelCreating(DbModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}

		public static AppIdentityDbContext Create()
		{
			return new AppIdentityDbContext();
		}

		public DbSet<UserInfo> UserInfos { get; set; }
		public DbSet<TransportRequest> TransportRequests { get; set; }
	}
}