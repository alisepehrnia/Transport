using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using Transport.Core.Entities.Transport;
using Transport.Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace Transport.Core.Entities.User
{
	public class AppUser : IdentityUser
	{
		[Display(Name = "نام کاربری")]
		public override string UserName { get; set; }

		public AppUser()
		{
			TransportRequests = new HashSet<TransportRequest>();
		}

		/// <summary>
		/// Contains Name, NationalId, Address, Role and Requests
		/// </summary>
		//public UserInfo UserInfo { get; set; }

		//Nav
		public virtual ICollection<TransportRequest> TransportRequests { get; set; }

		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser, string> manager)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(this, AuthConstants.DefaultAuthenticationType);
			// Add custom user claims here
			return userIdentity;
		}
	}
}