using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Transport.Core.Entities.Transport;
using Transport.Core.Entities.User;

namespace Transport.Infrastructure.Data.DataAccess
{
	public class TransportDbContext : IdentityDbContext<AppUser>
	{
		private const string ConnectionName = "name=TransportConnectionString";

		public TransportDbContext() : base(ConnectionName, throwIfV1Schema: false)
		{
		}

		protected override void OnModelCreating(DbModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}

		public static TransportDbContext Create()
		{
			return new TransportDbContext();
		}

		public DbSet<UserInfo> UserInfos { get; set; }
		public DbSet<TransportRequest> TransportRequests { get; set; }

		public DbSet<AppUser> AppUsers => base.Set<AppUser>();
		public DbSet<AppRole> AppRoles => base.Set<AppRole>();
	}
}