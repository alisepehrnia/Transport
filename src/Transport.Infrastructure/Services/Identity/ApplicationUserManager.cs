using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Transport.Core.Constants;
using Transport.Infrastructure.Identity;

namespace Transport.Infrastructure.Services.Identity
{
	// Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
	public class ApplicationUserManager : UserManager<ApplicationUser>
	{
		public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
		{
		}

		public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
		{
			var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<AppIdentityDbContext>()));

			// Configure validation logic for usernames
			manager.UserValidator = UserManagerDefaults.GetDefaultUserValidator(manager);

			// Configure validation logic for passwords
			manager.PasswordValidator = UserManagerDefaults.PasswordValidator;

			// Configure user lockout defaults
			manager.UserLockoutEnabledByDefault = AuthConstants.UserLockoutEnabledByDefault;
			manager.DefaultAccountLockoutTimeSpan = AuthConstants.DefaultAccountLockoutTimeSpan;
			manager.MaxFailedAccessAttemptsBeforeLockout = AuthConstants.MaxFailedAccessAttemptsBeforeLockout;

			var dataProtectionProvider = options.DataProtectionProvider;
			if (dataProtectionProvider != null)
			{
				manager.UserTokenProvider = UserManagerDefaults.GetDefaultDataProtectorTokenProvider(dataProtectionProvider);
			}

			return manager;
		}
	}
}
