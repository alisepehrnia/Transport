using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Transport.Core.Entities
{
	public class User
	{
		public User()
		{
			Requests = new HashSet<Request>();
		}

		[Key]
		public int UserId { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string NationalId { get; set; }

		public string Address { get; set; }

		[Required]
		//FK: UserRoleId
		public virtual UserRole Role { get; set; }

		//Nav
		public virtual ICollection<Request> Requests { get; set; }
	}
}