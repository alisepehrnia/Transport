using System;
using System.ComponentModel.DataAnnotations;
using Transport.Core.Entities.User;

namespace Transport.Core.Entities.Transport
{
	/// <summary>
	/// General Request Object With Id, AppUser and DateTime
	/// </summary>
	public abstract class Request
	{
		protected Request()
		{
		}

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
		[Display(Name = "شناسه درخواست")]
		public int RequestId { get; set; }

		/// <summary>
		/// DateTime When This Request Has Been Made 
		/// </summary>
		[Required]
		[Display(Name = "تاریخ ثبت")]
		public DateTime DateTime { get; set; }

		/// <summary>
		/// User Who Made This Request
		/// </summary>
		[Required]
		[Display(Name = "کاربر")]
		public virtual AppUser User { get; set; }
	}
}