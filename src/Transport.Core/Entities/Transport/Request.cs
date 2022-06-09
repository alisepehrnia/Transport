using System;
using System.ComponentModel.DataAnnotations;
using Transport.Core.Entities.User;

namespace Transport.Core.Entities.Transport
{
	public abstract class Request
	{
		/// <summary>
		/// Makes New Request By Provided AppUser And DateTime.Now
		/// </summary>
		protected Request(AppUser user)
		{
			User = user;
			DateTime = DateTime.Now;
		}

		/// <summary>
		/// Makes New Request By Provided AppUser And DateTime
		/// </summary>
		protected Request(AppUser user, DateTime dateTime)
		{
			User = user;
			DateTime = dateTime;
		}

		[Key]
		public int RequestId { get; set; }

		/// <summary>
		/// DateTime When This Request Has Been Made 
		/// </summary>
		[Required]
		public DateTime DateTime { get; set; }

		/// <summary>
		/// User Who Made This Request
		/// </summary>
		[Required]
		public virtual AppUser User { get; set; }
	}
}