using System.Collections.Generic;
using Transport.Core.Enums;
using Transport.Core.Extensions;

namespace Transport.Core.Constants
{
	/// <summary>
	/// Constants Showing Roles And Their Premissions Such as Create Request & Confirm Request
	/// CAUTION: Not Working Directly In Controller Annotations Yet!
	/// </summary>
	public static class PremissionConstants
	{
		/// <summary>
		/// Map App Tasks To List Of UserRoles
		/// </summary>
		internal static readonly Dictionary<AppTasks, List<UserRoles>> TaskRoles = new Dictionary<AppTasks, List<UserRoles>>
		{
			//Roles Who Can Create New Users: Admin
			{
				AppTasks.CreateUser,
				new List<UserRoles>() { UserRoles.Admin }
			},
			//Roles Who Can Create New Transport Requests: Manager, MiddleManager, Employee
			{
				AppTasks.CreateTransportRequest,
				new List<UserRoles>() { UserRoles.Manager, UserRoles.MiddleManager, UserRoles.Employee }
			},
			//Roles Who Can Confirm Transport Requests: Manager, MiddleManager
			{
				AppTasks.ConfirmTransportRequest,
				new List<UserRoles>() { UserRoles.Manager, UserRoles.MiddleManager }
			},
		};

		/// <summary>
		/// Get Name Of Roles Who Have Premissions To Do Specified AppTask
		/// </summary>
		/// <param name="appTask"></param>
		/// <returns></returns>
		public static IEnumerable<string> GetPremissionRoleNames(AppTasks appTask)
		{
			return TaskRoles[appTask].GetNames();
		}
	}
}
