using System;
using System.ComponentModel.DataAnnotations;

namespace Transport.Core.Entities
{
	public class Request
	{
		[Key]
		public int RequestId { get; set; }

		[Required]
		public DateTime DateTime { get; set; }

		[Required]
		//FK: UserId
		public virtual UserInfo Issuer { get; set; }
	}
}