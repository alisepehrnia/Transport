namespace Transport.Core.Enums
{
	/// <summary>
	/// Roles Of Users.
	/// Hint: Values Representing Level Of User (Lower Numbers Are More Powerful And Have More Premissions)
	/// Hint: Have 10x Values To Have Spaces In Between For Further Role Levels
	/// </summary>
	public enum UserRoles
	{
		/// <summary>
		/// Can Create New User.
		/// Hint: Is Negative Number To Easily Exclude From Approval Logics
		/// </summary>
		Admin = -10,
		/// <summary>
		/// Can Create Transport Requests And Confirm/Reject MiddleManager And Employee Transport Requests
		/// </summary>
		Manager = 10,
		/// <summary>
		/// Can Create Transport Requests And Confirm/Reject Employee Transport Requests
		/// </summary>		
		MiddleManager = 20,
		/// <summary>
		/// Can Create Transport Requests
		/// </summary>
		Employee = 30,
		/// <summary>
		/// Can See Transport Requests
		/// </summary>
		Driver = 40
	}
}