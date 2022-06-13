using System.Collections.Generic;
using System;
using Transport.Core.Entities.User;
using System.Linq;

namespace Transport.Infrastructure.Data
{
	public static class AppUserRoleLevelExtensions
	{
		/// <summary>
		/// Extension Method Wich Converts AppUserRoleLevelModel's To Tuples of (AppUser, level)
		/// </summary>
		/// <param name="userRoleLevels">AppUserRoleLevelModel's</param>
		/// <returns>IEnumerable<Tuple<AppUser, int>></returns>
		public static IEnumerable<Tuple<AppUser, int>> ToUserLevelTuples(this IEnumerable<AppUserRoleLevelModel> userRoleLevels)
		{
			return userRoleLevels.Select(u => new Tuple<AppUser, int>(u.User, u.Level));
		}

		/// <summary>
		/// Extension Method Wich Converts AppUserRoleLevelModel's To IEnumerable<string>
		/// </summary>
		/// <param name="userRoleLevels">AppUserRoleLevelModel's</param>
		/// <returns>IEnumerable<string></returns>
		public static IEnumerable<string> ToUserNames(this IEnumerable<AppUserRoleLevelModel> userRoleLevels)
		{
			return userRoleLevels.Select(u => u.User.UserName);
		}
	}
}
