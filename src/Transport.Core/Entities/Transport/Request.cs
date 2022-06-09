using System;
using System.ComponentModel.DataAnnotations;
using Transport.Core.Entities.User;

namespace Transport.Core.Entities.Transport
{
	public abstract class Request
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