using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Transport.Core.Entities.Transport;
using Transport.Core.Entities.User;

namespace Transport.Infrastructure.Data.DataAccess
{
	public class TransportDbContext : IdentityDbContext<AppUser, AppRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
	{
		private const string ConnectionName = "name=TransportConnectionString";

		public TransportDbContext() : base(ConnectionName)
		{
		}

		static TransportDbContext()
		{
			// Set the database initializer which is run once during application start
			// This seeds the database with admin user credentials and admin role
			//Database.SetInitializer<TransportDbContext>(new TransportDbInit());
		}

		public static TransportDbContext Create()
		{
			return new TransportDbContext();
		}

		protected override void OnModelCreating(DbModelBuilder builder)
		{
			base.OnModelCreating(builder);

			#region AppUser

			//App User Has EXACT 1 User Info Associated With
			//User Info Has EXACT 1 App User Associated With
			//(1 To 1)
			builder.Entity<AppUser>()
				.HasRequired(t => t.UserInfo)
				.WithRequiredPrincipal(t => t.User);

			//Users May Have 0..* Transport Request
			//Each Transport Request Have EXACT 1 User Associated With
			//(1 To Many)
			builder.Entity<AppUser>()
				.HasMany(t => t.TransportRequests)
				.WithRequired(t => t.User);

			#endregion

			#region TransportRequest

			//Configure Base Type Key Property As Primary Key
			builder.Entity<TransportRequest>()
				.HasKey(t => t.RequestId);

			//Transport Request Is Belong To EXACT 1 User
			//User May Have 0..* Transport Requests
			//(1 To Many)
			builder.Entity<TransportRequest>()
				.HasRequired(t => t.User)
				.WithMany(t => t.TransportRequests);

			//Transport Request May Have 0..1 Confirm Chain
			builder.Entity<TransportRequest>()
				.HasOptional(t => t.ConfirmChain);

			#endregion

			#region TransportRequestConfirmChain

			//Configure Base Type Key Property As Primary Key
			builder.Entity<TransportRequestConfirmChain>()
				.HasKey(t => t.ConfirmChainId);

			//TransportRequestConfirmChain Consists Of 0..* TransportRequestConfirm
			builder.Entity<TransportRequestConfirmChain>()
				.HasMany(t => t.Confirms);

			#endregion

			#region TransportRequestConfirm

			//Configure Base Type Key Property As Primary Key
			builder.Entity<TransportRequestConfirm>()
					.HasKey(t => t.ConfirmId);

			//TransportRequestConfirm Has EXACT 1 User
			builder.Entity<TransportRequestConfirm>()
				.HasRequired(t => t.User);

			//TransportRequestConfirm Has EXACT 1 Request
			builder.Entity<TransportRequestConfirm>()
				.HasRequired(t => t.Request);

			#endregion
		}

		public DbSet<TransportRequest> TransportRequests { get; set; }

		public DbSet<TransportRequestConfirm> TransportRequestConfirms { get; set; }

		public DbSet<TransportRequestConfirmChain> TransportRequestConfirmChains { get; set; }
	}
}