using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using Transport.Core.Entities;

namespace Transport.Infrastructure.Identity
{
	// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class ApplicationUser : IdentityUser
	{
		public ApplicationUser()
		{
			TransportRequests = new HashSet<TransportRequest>();
		}

		/// <summary>
		/// Contains Name, NationalId, Address, Role and Requests
		/// </summary>
		public UserInfo UserInfo { get; set; }

		//Nav
		public virtual ICollection<TransportRequest> TransportRequests { get; set; }

		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			// Add custom user claims here
			return userIdentity;
		}
	}
}