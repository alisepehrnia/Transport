using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using Transport.Core.Entities.User;

namespace Transport.Infrastructure.Services.Identity
{
	public static class UserManagerDefaults
	{
		public static UserValidator<AppUser> GetDefaultUserValidator(AppUserManager manager)
		{
			return new UserValidator<AppUser>(manager)
			{
				AllowOnlyAlphanumericUserNames = true,
				RequireUniqueEmail = false
			};
		}

		public static PasswordValidator PasswordValidator => new PasswordValidator
		{
		};

		public static DataProtectorTokenProvider<AppUser> GetDefaultDataProtectorTokenProvider(IDataProtectionProvider protectionProvider)
		{
			return new DataProtectorTokenProvider<AppUser>(protectionProvider.Create("ASP.NET Identity"));
		}
	}
}
