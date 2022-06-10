using System.ComponentModel.DataAnnotations;
using Transport.Core.Entities.User;
using Transport.Core.Enums;

namespace Transport.Core.Entities.Transport
{
	/// <summary>
	/// Confirm Object Represents A Request To Be Confirmed,
	/// AppUser Responsible For Confirmation and The State Of Confirm
	/// </summary>
	/// <typeparam name="TRequest">Request Object Type (MUST Be Derived From Transport.Request)</typeparam>
	public class Confirm<TRequest> where TRequest : Request
	{
		public Confirm(AppUser user, TRequest request)
		{
			User = user;
			Request = request;
		}

		public Confirm(AppUser user, TRequest request, RequestState state) : this(user, request)
		{
			State = state;
		}

		public Confirm(AppUser user, TRequest request, RequestState state, int priority) : this(user, request, state)
		{
			Priority = priority;
		}

		public int ConfirmId { get; set; }

		/// <summary>
		/// User Who Is Responsible For Confirm
		/// </summary>
		[Required]
		public virtual AppUser User { get; set; }

		/// <summary>
		/// Request To Confirm
		/// </summary>
		[Required]
		public virtual TRequest Request { get; set; }

		/// <summary>
		/// State Of Request Confirmation
		/// </summary>
		[Required]
		public RequestState State { get; set; } = RequestState.Initial;

		/// <summary>
		/// Relative Priority Of This Confirm In Confirms Chain of a Request
		/// </summary>
		[Required]
		public int Priority { get; set; }

		//Hepers
		public bool IsInitial => State == RequestState.Initial;
		public bool IsRejected => State == RequestState.Rejected;
		public bool IsConfirmed => State == RequestState.Confirmed;
	}
}
