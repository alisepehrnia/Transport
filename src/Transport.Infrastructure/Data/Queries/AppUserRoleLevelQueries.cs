using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Transport.Core.Entities.User;
using Transport.Infrastructure.Data.DataAccess;

namespace Transport.Infrastructure.Data.Queries
{
	public static class AppUserRoleLevelQueries
	{
		/// <summary>
		/// Generate An AppUserRoleLevelModel From AppUsers.
		/// CAUTION: This Method Only Consider User First And Only First Role
		/// </summary>
		/// <param name="user">AppUser</param>
		/// <param name="_db"></param>
		/// <returns>AppUserRoleLevelModel</returns>
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

		/// <summary>
		/// Generate All AppUserRoleLevelModel From AppUsers In DB
		/// </summary>
		/// <param name="_db"></param>
		/// <returns>IEnumerable<AppUserRoleLevelModel></returns>
		public static IEnumerable<AppUserRoleLevelModel> GetAll(TransportDbContext _db)
		{
			var result = new List<AppUserRoleLevelModel>();
			foreach (var user in _db.Users.Include(u => u.Roles))
			{
				result.Add(user.ToAppUserRoleLevelModel(_db));
			}
			return result;
		}

		/// <summary>
		/// Single Or Default AppUserRoleLevelModel By UserName
		/// </summary>
		/// <param name="_db"></param>
		/// <param name="username"></param>
		/// <returns>AppUserRoleLevelModel or null</returns>
		public static AppUserRoleLevelModel GetByUserName(TransportDbContext _db, string username)
		{
			var user = _db.Users.SingleOrDefault(x => x.UserName == username);
			return user.ToAppUserRoleLevelModel(_db);
		}

		/// <summary>
		/// Get AppUserRoleLevelModel's With Levels Higher Than Specified Level
		/// </summary>
		/// <param name="_db"></param>
		/// <param name="level">Level Threshold</param>
		/// <returns>IEnumerable<AppUserRoleLevelModel></returns>
		public static IEnumerable<AppUserRoleLevelModel> GetHigherLevels(TransportDbContext _db, int level)
		{
			return GetAll(_db).Where(u => u.Level > level);
		}

		/// <summary>
		/// Extension Method Wich Converts AppUserRoleLevelModel's To Tuples of (AppUser, level)
		/// </summary>
		/// <param name="userRoleLevels">AppUserRoleLevelModel's</param>
		/// <returns>IEnumerable<Tuple<AppUser, int>></returns>
		public static IEnumerable<Tuple<AppUser, int>> ToUserLevelTuples(this IEnumerable<AppUserRoleLevelModel> userRoleLevels)
		{
			return userRoleLevels.Select(u => new Tuple<AppUser, int>(u.User, u.Level));
		}
	}
}
