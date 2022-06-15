namespace Transport.Core.Enums
{
	/// <summary>
	/// Showing State Of Request: Initial(-1), Rejected(0) Or Confirmed(1)
	/// </summary>
	public enum RequestState
	{
		/// <summary>
		/// Not Rejected Nor Confirmed
		/// </summary>
		Initial = -1,
		/// <summary>
		/// Not Approved
		/// </summary>
		Rejected,
		/// <summary>
		/// Approved
		/// </summary>
		Confirmed
	}
}
