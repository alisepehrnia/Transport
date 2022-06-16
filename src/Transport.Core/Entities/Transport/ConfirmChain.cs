using System.Collections.Generic;
using System.Linq;
using Transport.Core.Enums;

namespace Transport.Core.Entities.Transport
{
	/// <summary>
	/// Represents A Chain Of Sorted Confirms (Designed For Down To Top Hierarchical Confirmation Proccess).
	/// Hint: All Confirms Must Be Accepted/Rejected To Represent A Successfull State Of This Confirm Chain
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

		/// <summary>
		/// Collection Of Confirms Which Are Subset Of This Chain 
		/// </summary>
		public ICollection<TConfirm> Confirms { get; set; }

		/// <summary>
		/// Is Any Rejected
		/// </summary>
		public bool IsRejected => Confirms.Any(c => c.IsRejected);
		/// <summary>
		/// Is All Confirmed
		/// </summary>
		public bool IsConfirmed => Confirms.All(c => c.IsConfirmed);
		/// <summary>
		/// Not Any Rejected Nor All Confirmed
		/// </summary>
		public bool IsInitial => !IsRejected && !IsConfirmed;

		/// <summary>
		/// Rejected If Any Confirm Rejected. Confirmed If All Confirms Confirmed.
		/// Else Initial
		/// </summary>
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
		/// First Confirm In The Chain Which Is Not Confirmed Nor Rejected (First Or Default Confirm With Highest Priority Wich Is Initial)
		/// </summary>
		public TConfirm ConfirmChainState => Confirms.OrderByDescending(c => c.Priority)
			.FirstOrDefault(c => c.IsInitial);
	}
}
