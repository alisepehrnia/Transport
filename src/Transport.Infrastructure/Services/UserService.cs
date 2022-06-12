using System.Collections.Generic;
using System.Linq;
using Transport.Core.Entities.User;
using Transport.Infrastructure.Data;

namespace Transport.Infrastructure.Services
{
	internal class UserService
	{
		private readonly TransportRepository<AppUser> _userService;

		public UserService(TransportRepository<AppUser> userService)
		{
			_userService = userService;
		}

		public Dictionary<AppRole, AppUser> GetAllWithRoles(List<AppRole> appRoles)
		{
			var allUsers = _userService.ListAsync();
			var result = new Dictionary<AppRole, AppUser>() { };
			foreach (var role in appRoles)
			{
				var user = allUsers.Result.FirstOrDefault(u => u.Roles.Any(r => r.RoleId == role.Id));
				result.Add(role, user);
			}
			return result;
		}
	}
}
