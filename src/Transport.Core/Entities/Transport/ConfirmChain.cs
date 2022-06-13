using System.Collections.Generic;
using System.Linq;
using Transport.Core.Enums;

namespace Transport.Core.Entities.Transport
{
	/// <summary>
	/// Represents A Chain Of Sorted Confirms (Designed For Down To Top Hierarchical Confirmation Proccess)
	/// </summary>
	/// <typeparam name="TConfirm">Confirm Object Type (MUST Be Derived From Confirm<TRequest>)</typeparam>
	/// <typeparam name="TRequest">Request Object Type (MUST Be Derived From Request)</typeparam>
	public class ConfirmChain<TConfirm, TRequest>
		where TConfirm : Confirm<TRequest>
		where TRequest : Request
	{
		public ConfirmChain()
		{
			Confirms = new HashSet<TConfirm>();
		}

		public int ConfirmChainId { get; set; }

		public ICollection<TConfirm> Confirms { get; set; }

		public bool IsRejected => Confirms.Any(c => c.IsRejected);
		public bool IsConfirmed => Confirms.All(c => c.IsConfirmed);
		public bool IsInitial => !IsRejected && !IsConfirmed;

		public RequestState ConfirmState
		{
			get
			{
				if (IsRejected) return RequestState.Rejected;
				else if (IsConfirmed) return RequestState.Confirmed;
				else return RequestState.Initial;
			}
		}

		/// <summary>
		/// First Confirm In The Chain Which Is Not Confirmed Nor Rejected
		/// </summary>
		public TConfirm ConfirmChainState => Confirms.FirstOrDefault(c => c.IsInitial);
	}
}
