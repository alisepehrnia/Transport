using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Transport.Core.Entities.User;
using Transport.Core.Enums;

namespace Transport.Core.Entities.Transport
{
	/// <summary>
	/// Extended Version Of Request Wich
	/// Include: TravelDateTime, Address & OtherUsers
	/// </summary>
	public class TransportRequest : Request
	{
		/// <summary>
		/// DateTime To Travel
		/// </summary>
		[Required]
		[Display(Name = "زمان حرکت")]
		public DateTime TravelDateTime { get; set; }

		/// <summary>
		/// Travel Destination Address
		/// </summary>
		[Required]
		[Display(Name = "آدرس")]
		public string Address { get; set; }

		//[Display(Name = "کاربران همراه")]
		///// <summary>
		///// Users Who Are Going To Travel With This Request (Except The Requester)
		///// </summary>
		//public ICollection<AppUser> OtherUsers { get; set; } //Commented Because Of EF Model Building Errors

		public TransportRequestConfirmChain ConfirmChain { get; set; }

		[NotMapped]
		[Display(Name = "وضعیت درخواست")]
		public RequestState? ConfirmState => ConfirmChain?.ConfirmState;

		public TransportRequest()
		{
		}

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
		//public TransportRequest(AppUser user, DateTime RequestDateTime, DateTime travelDateTime, string address,
		//	ICollection<AppUser> otherUsers = null) : this(user, RequestDateTime)
		//{
		//	TravelDateTime = travelDateTime;
		//	Address = address;
		//	//Prevents To Set OtherUsers Null 
		//	OtherUsers = otherUsers ?? _EmptyUserCollection;
		//}

		/// <summary>
		/// Makes New TransportRequest By Provided AppUser, DateTime of Request, DateTime To Travel,
		/// Destinaton Address and Optional Users Who Wants To Come
		/// </summary>
		/// <param name="user">Requester User</param>
		/// <param name="RequestDateTime">DateTime of Request</param>
		/// <param name="travelDateTime">DateTime To Travel</param>
		/// <param name="address">Destination Address</param>
		///// <param name="otherUser">User Who Are Going To Travel With This Request (In Addition To The Requester)</param>
		public TransportRequest(AppUser user, DateTime RequestDateTime, DateTime travelDateTime, string address) : this(user, RequestDateTime)
		{
			TravelDateTime = travelDateTime;
			Address = address;
			//Prevents To Set OtherUsers Null 
			//if (otherUser != null) OtherUser = otherUser;
		}

		/// <summary>
		/// Makes New TransportRequest By Provided AppUser, DateTime To Travel,
		/// Destinaton Address and Optional Users Who Wants To Come.
		/// Request DateTime = DateTime.Now
		/// </summary>
		/// <param name="user">Requester User</param>
		/// <param name="travelDateTime">DateTime To Travel</param>
		/// <param name="address">Destination Address</param>
		///// <param name="otherUser">User Who Are Going To Travel With This Request (In Addition To The Requester)</param>
		public TransportRequest(AppUser user, DateTime travelDateTime, string address)
			: this(user, DateTime.Now, travelDateTime, address)
		{
		}

		/// <summary>
		/// Makes New TransportRequest By Provided AppUser, DateTime To Travel,
		/// Destinaton Address and Optional Users Who Wants To Come.
		/// This Method Also Constructs New Confirm Chain & Populates It
		/// By Confirms That Come From higherLevel_userLevelTuples.
		/// Request DateTime = DateTime.Now
		/// </summary>
		/// <param name="user">Requester User</param>
		/// <param name="travelDateTime">DateTime To Travel</param>
		/// <param name="address">Destination Address</param>
		/// <param name="higherLevel_userLevelTuples"></param>
		public TransportRequest(AppUser user, DateTime travelDateTime, string address, IEnumerable<Tuple<AppUser, int>> higherLevel_userLevelTuples)
			: this(user, DateTime.Now, travelDateTime, address)
		{
			ConfirmChain = new TransportRequestConfirmChain(this, higherLevel_userLevelTuples);
		}
	}
}