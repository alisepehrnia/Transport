using System.Data.Entity.Migrations;

namespace Transport.Infrastructure.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<Data.DataAccess.TransportDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.DataAccess.TransportDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
