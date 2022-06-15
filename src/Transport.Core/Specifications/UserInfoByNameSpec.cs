using System.Linq;
using Ardalis.Specification;
using Transport.Core.Entities.User;

namespace Transport.Core.Specifications
{
	/// <summary>
	/// Find UserInfo With Specified UserName
	/// </summary>
	public class UserInfoByNameSpec : Specification<UserInfo>
	{
		public UserInfoByNameSpec(string name)
		{
			Query.Where(u => u.Name == name);
		}
	}
}
