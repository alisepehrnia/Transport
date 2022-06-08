using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using Transport.Infrastructure.Identity;

namespace Transport.Infrastructure.Services.Identity
{
	public static class UserManagerDefaults
	{
		public static UserValidator<ApplicationUser> GetDefaultUserValidator(ApplicationUserManager manager)
		{
			return new UserValidator<ApplicationUser>(manager)
			{
				AllowOnlyAlphanumericUserNames = false,
				RequireUniqueEmail = true,
			};
		}

		public static PasswordValidator PasswordValidator => new PasswordValidator
		{
		};

		public static DataProtectorTokenProvider<ApplicationUser> GetDefaultDataProtectorTokenProvider(IDataProtectionProvider protectionProvider)
		{
			return new DataProtectorTokenProvider<ApplicationUser>(protectionProvider.Create("ASP.NET Identity"));
		}
	}
}
