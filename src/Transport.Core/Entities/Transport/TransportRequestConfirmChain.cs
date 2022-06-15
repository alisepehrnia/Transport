using System;
using System.Collections.Generic;
using Transport.Core.Entities.User;

namespace Transport.Core.Entities.Transport
{
	/// <summary>
	/// Custom Version Of Confirm Chain Customed For TransportRequest And TransportRequestConfirm
	/// </summary>
	public class TransportRequestConfirmChain : ConfirmChain<TransportRequestConfirm, TransportRequest>
	{
		public TransportRequestConfirmChain()
		{
		}

		/// <summary>
		/// Populate Confirms With Specified Higher Level Users And Provided Request
		/// </summary>
		/// <param name="request"></param>
		/// <param name="higherLevelUsers"></param>
		public TransportRequestConfirmChain(TransportRequest request, IEnumerable<Tuple<AppUser, int>> higherLevelUsers)
		{
			foreach (var userLevel in higherLevelUsers)
			{
				Confirms.Add(new TransportRequestConfirm(userLevel.Item1, request, userLevel.Item2));
			}
		}
	}
}
