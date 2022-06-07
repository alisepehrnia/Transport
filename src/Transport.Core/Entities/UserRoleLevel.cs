using System.ComponentModel.DataAnnotations;
using Transport.Core.Enums;

namespace Transport.Core.Entities
{
	public class UserRoleLevel
	{
		[Key]
		public int UserRoleLevelId { get; set; }

		[Required]
		public UserRoles Role { get; set; }

		[Required]
		public uint RoleLevel { get; set; }

		[Required]
		//FK: UserRoleId
		public virtual UserRole UserRole { get; set; }
	}
}