using System.Data.Entity;
using Transport.Core.Entities;

namespace Transport.Infrastructure.Data.DataAccess
{
	public class TransportContext : DbContext
	{
		public TransportContext() : base("name=TransportConnectionString") { }

		protected override void OnModelCreating(DbModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}

		public DbSet<UserInfo> Users { get; set; }
		public DbSet<UserRole> UserRoles { get; set; }
		public DbSet<UserRoleLevel> UserRoleLevels { get; set; }
		public DbSet<TransportRequest> TransportRequests { get; set; }
	}
}