using Transport.Core.Entities.User;
using Transport.Core.Enums;

namespace Transport.Core.Entities.Transport
{
	public class TransportRequestConfirm : Confirm<TransportRequest>
	{
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
	}
}
