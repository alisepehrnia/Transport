using System.Collections.Generic;
using System.Threading.Tasks;
using Transport.Core.Entities.User;
using Transport.Core.Specifications;
using Transport.Infrastructure.Data;

namespace Transport.Infrastructure.Services
{
	internal class UserInfoService
	{
		private readonly TransportRepository<UserInfo> _userInfoRepository;

		public UserInfoService(TransportRepository<UserInfo> userInfoRepository)
		{
			_userInfoRepository = userInfoRepository;
		}

		public Task<List<UserInfo>> GetUserByName(string lastname)
		{
			return _userInfoRepository.ListAsync(new UserInfoByNameSpec(lastname));
		}
	}
}
