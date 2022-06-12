using System;
using System.Linq;
using Transport.Core.Entities.User;
using Transport.Infrastructure.Data.DataAccess;

namespace Transport.Infrastructure.Data.Queries
{
	public static class AppUserRoleLevelQueries
	{
		private static AppUserRoleLevelModel ToAppUserRoleLevelModel(this AppUser user, TransportDbContext _db)
		{
			var roleId = user.Roles.First().RoleId;
			var role = _db.Roles.Find(roleId);
			return new AppUserRoleLevelModel
			{
				User = user,
				Role = role,
				Level = role.Level
			};
		}

		public static IQueryable<AppUserRoleLevelModel> GetAll(TransportDbContext _db)
		{
			return _db.Users.Select(u => u.ToAppUserRoleLevelModel(_db));
		}

		public static AppUserRoleLevelModel GetByName(TransportDbContext _db, string name)
		{
			var user = _db.Users.SingleOrDefault(x => x.UserName == name);
			return user.ToAppUserRoleLevelModel(_db);
		}

		public static IQueryable<AppUserRoleLevelModel> GetHigherLevels(TransportDbContext _db, int level)
		{
			return GetAll(_db).Where(u => u.Level > level);
		}

		public static IQueryable<Tuple<AppUser, int>> ToUserLevelTuples(this IQueryable<AppUserRoleLevelModel> higherLevelUsers)
		{
			return higherLevelUsers.Select(u => new Tuple<AppUser, int>(u.User, u.Level));
		}
	}
}
