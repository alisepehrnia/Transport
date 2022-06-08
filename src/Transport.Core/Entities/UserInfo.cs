using System.ComponentModel.DataAnnotations;

namespace Transport.Core.Entities
{
	public class UserInfo
	{
		public UserInfo()
		{
		}

		[Key]
		public int UserId { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string NationalId { get; set; }

		public string Address { get; set; }
	}
}