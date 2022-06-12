using Transport.Core.Entities.User;
using Transport.Core.Enums;

namespace Transport.Core.Entities.Transport
{
	/// <summary>
	/// Special Confirm Object Which Represents A Transport Request To Be Confirmed,
	/// AppUser Responsible For Confirmation and The State Of Confirm
	/// </summary>
	public class TransportRequestConfirm : Confirm<TransportRequest>
	{
		public TransportRequestConfirm()
		{
		}

		public TransportRequestConfirm(AppUser user, TransportRequest request) : base(user, request)
		{
		}

		public TransportRequestConfirm(AppUser user, TransportRequest request, RequestState state) : base(user, request, state)
		{
		}

		public TransportRequestConfirm(AppUser user, TransportRequest request, RequestState state, int priority)
			: base(user, request, state, priority)
		{
		}

		public TransportRequestConfirm(AppUser user, TransportRequest request, int priority)
			: base(user, request, RequestState.Initial, priority)
		{
		}
	}
}
