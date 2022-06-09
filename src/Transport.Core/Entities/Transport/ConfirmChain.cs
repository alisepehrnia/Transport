using System.Collections.Generic;
using System.Linq;

namespace Transport.Core.Entities.Transport
{
	/// <summary>
	/// Represents A Chain Of Sorted Confirms (Designed For Down To Top Hierarchical Confirmation Proccess)
	/// </summary>
	/// <typeparam name="TRequest">Request Object Type (MUST Be Derived From Transport.Request)</typeparam>
	public class ConfirmChain<TRequest> where TRequest : Request
	{
		public ConfirmChain()
		{
			Confirms = new SortedSet<Confirm<TRequest>>();
		}

		public SortedSet<Confirm<TRequest>> Confirms { get; set; }

		public bool IsRejected => Confirms.Any(c => c.IsRejected);
		public bool IsConfirmed => Confirms.All(c => c.IsApproved);

		public Confirm<TRequest> ConfirmChainState => Confirms.FirstOrDefault(c => c.IsInitial);
	}
}
