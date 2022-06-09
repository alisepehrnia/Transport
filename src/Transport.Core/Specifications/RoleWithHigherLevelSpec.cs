using System.Linq;
using Ardalis.Specification;
using Transport.Core.Entities.User;

namespace Transport.Core.Specifications
{
	public class RoleWithHigherLevelSpec : Specification<AppRole>
	{
		public RoleWithHigherLevelSpec(int level)
		{
			Query.Where(u => u.Level > level);
		}
	}
}
