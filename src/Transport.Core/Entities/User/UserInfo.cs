using System.ComponentModel.DataAnnotations;

namespace Transport.Core.Entities.User
{
	/// <summary>
	/// Contains Name, NationalId, Address, Role and Requests For An App User
	/// CAUTION: Not Utilized (Commented Out In Calling Class: AppUser)
	/// </summary>
	public class UserInfo
	{
		public UserInfo()
		{
		}

		[Key]
		public int UserInfoId { get; set; }

		public virtual AppUser User { get; set; }

		[Required]
		public string Name { get; set; }

		public string NationalId { get; set; }

		public string Address { get; set; }
	}
}