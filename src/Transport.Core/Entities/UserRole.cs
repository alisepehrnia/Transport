using System.ComponentModel.DataAnnotations;
using Transport.Core.Enums;

namespace Transport.Core.Entities
{
	public class UserRole
	{
		[Key]
		public int UserRoleId { get; set; }

		[Required]
		//FK: UserRoleLevelId
		public virtual UserRoleLevel UserRoleLevel { get; set; }

		/// <summary>
		/// UserRoleLevel.Role
		/// </summary>
		public UserRoles Role => UserRoleLevel.Role;

		/// <summary>
		/// Role.ToString()
		/// </summary>
		//public string RoleName => Role.ToString();

		/// <summary>
		/// UserRoleLevel.RoleLevel
		/// </summary>
		//public int RoleLevel => UserRoleLevel.RoleLevel;
	}
}