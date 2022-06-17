using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Trasnsport.WebUI.Controllers
{
	/// <summary>
	/// Provides Helper Properties And Methods To Controllers: AuthenticationManager, ModelErrors & ...
	/// </summary>
	public class CustomController : Controller
	{
		/// <summary>
		/// Owin Context Authentication
		/// </summary>
		protected IAuthenticationManager AuthenticationManager
		{
			get
			{
				return HttpContext.GetOwinContext().Authentication;
			}
		}

		/// <summary>
		/// Add <paramref name="result"/> Errors To ModelState
		/// </summary>
		/// <param name="result"></param>
		protected void AddErrors(IdentityResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError("", error);
			}
		}

		/// <summary>
		/// Redirect To <paramref name="returnUrl"/> If Its Local otherwise Redirect To Home Index
		/// </summary>
		/// <returns>ActionResult</returns>
		protected ActionResult RedirectToLocalOrHome(string returnUrl)
		{
			if (Url.IsLocalUrl(returnUrl))
			{
				return Redirect(returnUrl);
			}
			return RedirectToAction("Index", "Home");
		}
	}
}