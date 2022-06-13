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
		/// CAUTION: Level Increases From Managers To Drivers and etc (Managers Have Lower Levels)
		/// </summary>
		/// <param name="_db"></param>
		/// <param name="level">Level Threshold</param>
		/// <returns>IEnumerable<AppUserRoleLevelModel></returns>
		public static IEnumerable<AppUserRoleLevelModel> GetHigherLevels(TransportDbContext _db, int level)
		{
			return GetAll(_db).Where(u => u.Level > level);
		}

		/// <summary>
		/// Get AppUserRoleLevelModel's With Levels Lower Than Specified Level
		/// CAUTION: Level Increases From Managers To Drivers and etc (Managers Have Lower Levels)
		/// </summary>
		/// <param name="_db"></param>
		/// <param name="level">Level Threshold</param>
		/// <returns>IEnumerable<AppUserRoleLevelModel></returns>
		public static IEnumerable<AppUserRoleLevelModel> GetLowerLevels(TransportDbContext _db, int level)
		{
			return GetAll(_db).Where(u => u.Level < level);
		}

		/// <summary>
		/// Get AppUserRoleLevelModel's With Specified RoleName
		/// </summary>
		/// <param name="_db"></param>
		/// <param name="roleName"></param>
		/// <returns></returns>
		public static IEnumerable<AppUserRoleLevelModel> GetByRoleName(TransportDbContext _db, string roleName)
		{
			return GetAll(_db).Where(u => u.Role.Name == roleName);
		}

		/// <summary>
		/// Get AppUserRoleLevelModel's With One Of Specified RoleNames
		/// </summary>
		/// <param name="_db"></param>
		/// <param name="roleNames"></param>
		/// <returns></returns>
		public static IEnumerable<AppUserRoleLevelModel> GetByRoleNames(TransportDbContext _db, params string[] roleNames)
		{
			var result = new List<AppUserRoleLevelModel>();
			var allUsers = GetAll(_db);
			foreach (var roleName in roleNames)
			{
				result.AddRange(allUsers.Where(u => u.Role.Name == roleName));
			}
			return result;
		}
	}
}
