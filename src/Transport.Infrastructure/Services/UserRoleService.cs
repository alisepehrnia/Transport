using System.Collections.Generic;
using System.Threading.Tasks;
using Transport.Core.Entities.User;
using Transport.Core.Specifications;
using Transport.Infrastructure.Data;

namespace Transport.Infrastructure.Services
{
	public class UserRoleService
	{
		private readonly TransportRepository<AppRole> _userRoleService;

		public UserRoleService(TransportRepository<AppRole> userRoleService)
		{
			_userRoleService = userRoleService;
		}

		public Task<List<AppRole>> GetHigherRoles(int level)
		{
			return _userRoleService.ListAsync(new RoleWithHigherLevelSpec(level));
		}
	}
}
