using System.Web.Mvc;

namespace Transport.WebUI.Controllers
{
	public class HomeController : Controller
	{
		//
		//GET: Website Index Page
		public ActionResult Index()
		{
			//Redirect To Login Page If Not Authenticated
			if (!Request.IsAuthenticated) return RedirectToAction("Login", "Account");
			else return View();
		}
	}
}