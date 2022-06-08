using System.Linq;
using Ardalis.Specification;
using Transport.Core.Entities;

namespace Transport.Core.Specifications
{
	public class UserInfoByNameSpec : Specification<UserInfo>
	{
		public UserInfoByNameSpec(string name)
		{
			Query.Where(u => u.Name == name);
		}
	}
}
