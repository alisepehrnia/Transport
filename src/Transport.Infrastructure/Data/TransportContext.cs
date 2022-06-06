using System.Data.Entity;

namespace Transport.Infrastructure.Data
{
	public class TransportContext : DbContext
	{
		public TransportContext(string nameOrConnectionString) : base(nameOrConnectionString)
		{
		}

		protected override void OnModelCreating(DbModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}