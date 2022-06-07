namespace Transport.Core.Enums
{
	public enum UserRoles
	{
		Manager = 1, //Can Issue Or Cancel Transport Requests And Approve MiddleManager And Employee Transport Requests
		Admin = 2, //Can Cancel Transport Requests
		MiddleManager = 3, //Can Issue Or Cancel Transport Requests And Approve Employee Transport Requests
		Employee = 4, //Can Issue Or Cancel Transport Requests
		Driver = 5 //Only Can Access Transport Receipts 
	}
}