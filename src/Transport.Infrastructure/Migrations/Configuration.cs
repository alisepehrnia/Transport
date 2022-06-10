namespace Transport.Infrastructure.Migrations
{
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<Transport.Infrastructure.Data.DataAccess.TransportDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Transport.Infrastructure.Data.DataAccess.TransportDbContext";
        }

        protected override void Seed(Transport.Infrastructure.Data.DataAccess.TransportDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
