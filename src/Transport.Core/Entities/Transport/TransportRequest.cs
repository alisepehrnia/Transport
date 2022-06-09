using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Transport.Core.Entities.User;

namespace Transport.Core.Entities.Transport
{
	/// <summary>
	/// Extended Version Of Request.
	/// Include: TravelDateTime, Address & OtherUsers
	/// </summary>
	public class TransportRequest : Request
	{
		private static readonly ICollection<AppUser> _EmptyUserCollection = new HashSet<AppUser>();

		/// <summary>
		/// Makes New TransportRequest By Provided AppUser And DateTime.Now
		/// </summary>
		public TransportRequest(AppUser user) : base(user)
		{
			Init();
		}

		/// <summary>
		/// Makes New TransportRequest By Provided AppUser And DateTime
		/// </summary>
		public TransportRequest(AppUser user, DateTime requestDateTime) : base(user, requestDateTime)
		{
			Init();
		}

		/// <summary>
		/// Initialize OtherUsers With Empty Collection And TravelDateTime With DateTime.Now
		/// </summary>
		private void Init()
		{
			OtherUsers = _EmptyUserCollection;
			TravelDateTime = DateTime.Now;
		}

		/// <summary>
		/// Makes New TransportRequest By Provided AppUser, DateTime of Request, DateTime To Travel,
		/// Destinaton Address and Optional Users Who Wants To Come
		/// </summary>
		/// <param name="user">Requester User</param>
		/// <param name="RequestDateTime">DateTime of Request</param>
		/// <param name="travelDateTime">DateTime To Travel</param>
		/// <param name="address">Destination Address</param>
		/// <param name="otherUsers">Users Who Are Going To Travel With This Request (Except The Requester)</param>
		public TransportRequest(AppUser user, DateTime RequestDateTime, DateTime travelDateTime, string address,
			ICollection<AppUser> otherUsers = null) : this(user, RequestDateTime)
		{
			TravelDateTime = travelDateTime;
			Address = address;
			//Prevents To Set OtherUsers Null 
			OtherUsers = otherUsers ?? _EmptyUserCollection;
		}

		/// <summary>
		/// Makes New TransportRequest By Provided AppUser, DateTime To Travel,
		/// Destinaton Address and Optional Users Who Wants To Come.
		/// Request DateTime = DateTime.Now
		/// </summary>
		/// <param name="user">Requester User</param>
		/// <param name="travelDateTime">DateTime To Travel</param>
		/// <param name="address">Destination Address</param>
		/// <param name="otherUsers">Users Who Are Going To Travel With This Request (Except The Requester)</param>
		public TransportRequest(AppUser user, DateTime travelDateTime, string address, ICollection<AppUser> otherUsers = null)
			: this(user, DateTime.Now, travelDateTime, address, otherUsers = null)
		{
		}

		/// <summary>
		/// DateTime To Travel
		/// </summary>
		[Required]
		public DateTime TravelDateTime { get; set; }

		/// <summary>
		/// Travel Destination Address
		/// </summary>
		[Required]
		public string Address { get; set; }

		/// <summary>
		/// Users Who Are Going To Travel With This Request (Except The Requester)
		/// </summary>
		public virtual ICollection<AppUser> OtherUsers { get; set; }

		public virtual ConfirmChain<TransportRequest> ConfirmChain { get; set; }
	}
}