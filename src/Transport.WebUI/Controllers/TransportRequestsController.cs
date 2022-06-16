using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using Transport.Core.Entities.Transport;
using Transport.Infrastructure.Data.DataAccess;
using Transport.Infrastructure.Data;
using System.Linq;
using Transport.Core.Enums;
using Transport.Core.Constants;
using Transport.Core.Extensions;
using Transport.Infrastructure.Data.Queries;

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

		/// <summary>
		/// Checks If Current HttpContext User Is Authorized To Do appTask Or Not
		/// </summary>
		public bool Authorized(AppTasks appTask)
		{
			return HttpContext.User.IsInRoles(PremissionConstants.GetPremissionRoleNames(appTask).ToArray());
		}

		// GET: TransportRequests
		// Lists All Requests
		public async Task<ActionResult> Index()
		{
			return View(Repo.GetByUserName(UserName));
		}

		// GET: TransportRequests/Confirmation
		// Lists All TransportRequests To Confirm
		public async Task<ActionResult> Confirmation()
		{
			if (!Authorized(AppTasks.ConfirmTransportRequest)) return new HttpUnauthorizedResult();
			return View(Repo.GetByConfirmCurrentStateUserName(UserName));
		}

		// GET: TransportRequests/ConfirmOrReject/5
		public async Task<ActionResult> ConfirmOrReject(int id, RequestState state)
		{
			if (!Authorized(AppTasks.ConfirmTransportRequest)) return new HttpUnauthorizedResult();
			var result = await Confirmation(id, state);
			ViewBag.Succeed = result >= 0;
			return View();
		}

		[NonAction]
		private async Task<int> Confirmation(int confirmId, RequestState state)
		{
			var request = await Repo.GetByIdAsync(confirmId);
			if (UserName != request.ConfirmChain.ConfirmChainState.User.UserName) return -1;
			var confirm = request.ConfirmChain.Confirms.SingleOrDefault(c => c.State == RequestState.Initial);
			confirm.State = state;
			db.Entry(confirm).State = EntityState.Modified;
			return await db.SaveChangesAsync();
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
			if (!Authorized(AppTasks.CreateTransportRequest)) return new HttpUnauthorizedResult();
			//Get All Users With Higher Or Equal Level Except Admin, Driver, And Current User Itself
			var otherUsersList = AppUserRoleLevelQueries.GetAllForOtherUsers(db, UserName);
			var otherUsersListItems = otherUsersList.ToListItems(u => u.User.UserName);
			ViewBag.OtherUsersListItems = otherUsersListItems;

			return View();
		}

		// POST: TransportRequests/Create
		// Creates New Request
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create([Bind(Include = "TravelDateTime,Address,OtherUsers")] TransportRequest req)
		{
			if (!Authorized(AppTasks.CreateTransportRequest)) return new HttpUnauthorizedResult();
			//To Bypass Request.User == null Error
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

		//// GET: TransportRequests/Edit/5
		//public async Task<ActionResult> Edit(int? id)
		//{
		//	var check = Repo.CheckExist(id);
		//	if (!check.IsSucceed)
		//	{
		//		return check.IsNotFound ? HttpNotFound() : check.GetStatusCode();
		//	}

		//	return View(check.Request);
		//}

		//// POST: TransportRequests/Edit/5
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<ActionResult> Edit([Bind(Include = "RequestId,TravelDateTime,Address,DateTime")] TransportRequest req)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		db.Entry(req).State = EntityState.Modified;
		//		await db.SaveChangesAsync();
		//		return RedirectToAction("Index");
		//	}
		//	return View(req);
		//}

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
