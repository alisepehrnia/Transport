using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Transport.Infrastructure.Services.Identity;
using Trasnsport.WebUI.ViewModels.Manage;

namespace Trasnsport.WebUI.Controllers
{
	[Authorize]
	public class ManageController : CustomController
	{
		private AppSignInManager _signInManager;
		private AppUserManager _userManager;

		public ManageController()
		{
		}

		public ManageController(AppUserManager userManager, AppSignInManager signInManager)
		{
			UserManager = userManager;
			SignInManager = signInManager;
		}

		public AppSignInManager SignInManager
		{
			get
			{
				return _signInManager ?? HttpContext.GetOwinContext().Get<AppSignInManager>();
			}
			private set
			{
				_signInManager = value;
			}
		}

		public AppUserManager UserManager
		{
			get
			{
				return _userManager ?? HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
			}
			private set
			{
				_userManager = value;
			}
		}

		//
		// GET: /Manage/Index
		public async Task<ActionResult> Index(ManageMessageId? message)
		{
			ViewBag.StatusMessage =
				message == ManageMessageId.Error ? "خطایی رخ داده است."
				: string.Empty;

			var userId = User.Identity.GetUserId();
			var model = new IndexViewModel
			{
				HasPassword = HasPassword(),
				PhoneNumber = await UserManager.GetPhoneNumberAsync(userId),
				TwoFactor = await UserManager.GetTwoFactorEnabledAsync(userId),
				Logins = await UserManager.GetLoginsAsync(userId),
				BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId)
			};
			return View(model);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && _userManager != null)
			{
				_userManager.Dispose();
				_userManager = null;
			}

			base.Dispose(disposing);
		}

		#region Helpers

		private bool HasPassword()
		{
			var user = UserManager.FindById(User.Identity.GetUserId());
			if (user != null)
			{
				return user.PasswordHash != null;
			}
			return false;
		}

		private bool HasPhoneNumber()
		{
			var user = UserManager.FindById(User.Identity.GetUserId());
			if (user != null)
			{
				return user.PhoneNumber != null;
			}
			return false;
		}

		public enum ManageMessageId
		{
			Error
		}

		#endregion
	}
}