using System.Data.Entity;

namespace Transport.Infrastructure.Data
{
	public class XContext : DbContext
	{
		public XContext(string nameOrConnectionString) : base(nameOrConnectionString)
		{
		}

		protected override void OnModelCreating(DbModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}