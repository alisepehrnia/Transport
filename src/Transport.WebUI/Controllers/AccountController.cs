using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Transport.Infrastructure.Services.Identity;
using Trasnsport.WebUI.App_Start;
using Trasnsport.WebUI.ViewModels.Account;
using Transport.Core.Extensions.AppIdentityExtensions;
using Transport.Core.Entities.User;

namespace Trasnsport.WebUI.Controllers
{
	[Authorize]
	public class AccountController : CustomController
	{
		private AppSignInManager _signInManager;
		private AppUserManager _userManager;
		private AppRoleManager _roleManager;

		public AccountController()
		{
		}

		public AccountController(AppUserManager userManager, AppSignInManager signInManager, AppRoleManager roleManager)
		{
			UserManager = userManager;
			SignInManager = signInManager;
			_roleManager = roleManager;
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

		public AppRoleManager RoleManager
		{
			get
			{
				return _roleManager ?? HttpContext.GetOwinContext().Get<AppRoleManager>();
			}
			private set
			{
				_roleManager = value;
			}
		}

		//
		// GET: /Account/Login
		[AllowAnonymous]
		public ActionResult Login(string returnUrl)
		{
			if (Request.IsAuthenticated) return RedirectToAction("Index", "Home");
			ViewBag.ReturnUrl = returnUrl;
			return View();
		}

		//
		// POST: /Account/Login
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);
			switch (result)
			{
				case SignInStatus.Success:
					return RedirectToLocalOrHome(returnUrl);
				case SignInStatus.LockedOut:
					return View("Lockout");
				case SignInStatus.Failure:
				default:
					ModelState.AddModelError("", "ورود ناموفق");
					return View(model);
			}
		}

		//
		// GET: /Account/Register
		[Authorize(Roles = "Admin")]
		public ActionResult Register()
		{
			return View();
		}

		//
		// POST: /Account/Register
		[HttpPost]
		[Authorize(Roles = "Admin")]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = new AppUser { UserName = model.UserName };
				var result = await UserManager.AddUser(model.UserName, model.Password);
				if (result.Succeeded)
				{
					//await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
					//return RedirectToAction("Index", "Home");

					ViewBag.RegisterDone = true;
					return View();
				}
				AddErrors(result);
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

		[AllowAnonymous]
		//
		// GET /Account/AddUsers
		public async Task<string> AddUsers()
		{
			await AppIdentityDbContextSeed.Init();
			return "Done!";
		}

		//
		// POST: /Account/LogOff
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult LogOff()
		{
			AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
			return RedirectToAction("Login", "Account");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_userManager != null)
				{
					_userManager.Dispose();
					_userManager = null;
				}

				if (_signInManager != null)
				{
					_signInManager.Dispose();
					_signInManager = null;
				}
			}

			base.Dispose(disposing);
		}
	}
}