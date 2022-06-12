using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using Transport.Core.Entities.Transport;
using Transport.Infrastructure.Data.DataAccess;
using Transport.Infrastructure.Data;

namespace Trasnsport.WebUI.Controllers
{
	//[Authorize(Roles = PremissionConstants.TRequestAndConfirmRoleNamesString)] Commented Because Its Not Working ):
	[Authorize(Roles = "Manager,MiddleManager,Employee")]
	public class TransportRequestsController : Controller
	{
		private readonly TransportDbContext db = new TransportDbContext();
		private readonly TRequestRepo Repo;
		private string UserName => HttpContext.User.Identity.Name;

		public TransportRequestsController()
		{
			Repo = new TRequestRepo(db);
		}

		// GET: TransportRequests
		// Lists All Requests
		public async Task<ActionResult> Index()
		{
			return View(Repo.GetByUserName(UserName));
		}

		// GET: TransportRequests/Details/5
		public async Task<ActionResult> Details(int? id)
		{
			var check = Repo.CheckExist(id);
			if (!check.IsSucceed)
			{
				return check.IsNotFound ? HttpNotFound() : check.GetStatusCode();
			}

			return View(check.Request);
		}

		// GET: TransportRequests/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: TransportRequests/Create
		// Creates New Request
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create([Bind(Include = "TravelDateTime,Address")] TransportRequest req)
		{
			ModelState["User"].Errors.Clear();
			var request = Repo.Create(UserName, req.TravelDateTime, req.Address);
			if (ModelState.IsValid)
			{
				await Repo.AddAsync(request);
				await Repo.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(req);
		}

		// GET: TransportRequests/Edit/5
		public async Task<ActionResult> Edit(int? id)
		{
			var check = Repo.CheckExist(id);
			if (!check.IsSucceed)
			{
				return check.IsNotFound ? HttpNotFound() : check.GetStatusCode();
			}

			return View(check.Request);
		}

		// POST: TransportRequests/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit([Bind(Include = "RequestId,TravelDateTime,Address,DateTime")] TransportRequest transportRequest)
		{
			if (ModelState.IsValid)
			{
				db.Entry(transportRequest).State = EntityState.Modified;
				await db.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(transportRequest);
		}

		// GET: TransportRequests/Delete/5
		public async Task<ActionResult> Delete(int? id)
		{
			var check = Repo.CheckExist(id);
			if (!check.IsSucceed)
			{
				return check.IsNotFound ? HttpNotFound() : check.GetStatusCode();
			}

			return View(check.Request);
		}

		// POST: TransportRequests/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(int id)
		{
			var request = await Repo.GetByIdAsync(id);
			await Repo.DeleteAsync(request);
			await Repo.SaveChangesAsync();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
