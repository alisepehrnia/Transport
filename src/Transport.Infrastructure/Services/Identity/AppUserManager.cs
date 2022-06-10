using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Transport.Core.Constants;
using Transport.Core.Entities.User;
using Transport.Infrastructure.Data.DataAccess;

namespace Transport.Infrastructure.Services.Identity
{
	// Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
	public class AppUserManager : UserManager<AppUser, string>
	{
		public AppUserManager(IUserStore<AppUser, string> store) : base(store)
		{
		}

		public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
		{
			var manager = new AppUserManager(
				new UserStore<AppUser, AppRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
				(context.Get<TransportDbContext>()));

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
