using System;
using Transport.Core.Entities.Transport;
using Transport.Infrastructure.Data.DataAccess;
using Transport.Infrastructure.Data.Queries;

namespace Transport.Infrastructure.Services
{
	public static class TransportRequestService
	{
		public static TransportRequest Create(TransportDbContext db, string userName, DateTime travelDateTime, string address)
		{
			var current = AppUserRoleLevelQueries.GetByName(db, userName);
			var higherLevel_userLevels = AppUserRoleLevelQueries.GetHigherLevels(db, current.Level).ToUserLevelTuples();
			return new TransportRequest(current.User, travelDateTime, address, higherLevel_userLevels);
		}
	}
}
