using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Ardalis.Specification;
using Ardalis.Specification.EntityFramework6;
using Transport.Core.Constants;
using Transport.Core.Entities.Transport;
using Transport.Core.Enums;
using Transport.Infrastructure.Data.DataAccess;
using Transport.Infrastructure.Data.Queries;

namespace Transport.Infrastructure.Data
{
	/// <summary>
	/// Repository For Working With Database TransportRequest's
	/// </summary>
	public class TRequestRepo : RepositoryBase<TransportRequest>
	{
		protected readonly TransportDbContext _db;
		public DbSet<TransportRequest> Requests => _db.TransportRequests;
		public IQueryable<TransportRequest> RequestsQ =>
			_db.TransportRequests.Include(r => r.ConfirmChain.Confirms)
			.Include(r => r.OtherUsers);

		public TRequestRepo(TransportDbContext db) : base(db)
		{
			_db = db;
		}

		/// <summary>
		/// Checks If id Provided & If id Points To Saved Transport Request
		/// </summary>
		/// <param name="id">Transport Request Id</param>
		/// <returns>ExistCheckResultModel</returns>
		public ExistCheckResultModel CheckExist(int? id)
		{
			var result = new ExistCheckResultModel();

			if (id == null)
			{
				result.HttpStatusCode = HttpStatusCode.BadRequest;
				return result;
			}

			var request = RequestsQ.FirstOrDefault(r => r.RequestId == id);
			if (request == null)
			{
				result.HttpStatusCode = HttpStatusCode.NotFound;
				return result;
			}

			result.Request = request;
			return result;
		}

		public async Task<TransportRequest> GetByIdAsync(int id)
		{
			return RequestsQ.SingleOrDefault(r => r.RequestId == id);
		}

		public IEnumerable<TransportRequest> FindWithSpecificationPattern(ISpecification<TransportRequest> specification = null)
		{
			return new SpecificationEvaluator().GetQuery(Requests.AsQueryable(), specification);
		}

		/// <summary>
		/// Creates New Transport Request And Populates It With Needed Data
		/// Such As AppUser, Confirm Chain Consrtuction and ...
		/// </summary>
		/// <param name="userName">User Who Wants To Travel</param>
		/// <param name="travelDateTime">DateTime To Start Travel</param>
		/// <param name="address">Destination Address</param>
		/// <returns>Complete Instance of TransportRequest</returns>
		public TransportRequest Create(string userName, DateTime travelDateTime, string address)
		{
			var current = AppUserRoleLevelQueries.GetByUserName(_db, userName);
			var lowerLevelConfirmators = HigherLowerLevelConfirmators(current, false).ToUserLevelTuples();
			return new TransportRequest(current.User, travelDateTime, address, lowerLevelConfirmators);
		}

		/* Replaced With GetByConfirmCurrentStateUserName() */
		/// <summary>
		/// Get Transport Requests With Travelers Whose Level Is Higher (Lower In Hierarchi) Than User With Specified UserName
		/// </summary>
		/// <param name="userName">Current User UserName</param>
		/// <returns>IEnumerable<TransportRequest></returns>
		public IEnumerable<TransportRequest> GetForConfirmation(string userName)
		{
			var current = AppUserRoleLevelQueries.GetByUserName(_db, userName);
			var higherLevelConfirmators = HigherLowerLevelConfirmators(current, true);
			return GetByUserNames(higherLevelConfirmators.ToUserNames().ToArray());
		}

		/// <summary>
		/// Joins Confirmator Roles With Higher/Lower Level Users Over UserId
		/// </summary>
		/// <param name="current">Current AppUserRoleLevel</param>
		/// <param name="getHighers"><see langword="true"/> To Get Higher Lower Level Roles and <see langword="false"/> To Get Lower Level Roles</param>
		/// <returns></returns>
		public IEnumerable<AppUserRoleLevelModel> HigherLowerLevelConfirmators(AppUserRoleLevelModel current, bool getHighers)
		{
			var confirmators = AppUserRoleLevelQueries.GetByRoleNames(_db,
				PremissionConstants.GetPremissionRoleNames(AppTasks.ConfirmTransportRequest).ToArray());
			var usersByLevel = !getHighers ? AppUserRoleLevelQueries.GetLowerLevels(_db, current.Level)
				: AppUserRoleLevelQueries.GetHigherLevels(_db, current.Level);
			return confirmators.Where(c => usersByLevel.Any(l => l.User.Id == c.User.Id));
		}

		/// <summary>
		/// Finds Transport Requests Whose User Has Specified UserName
		/// </summary>
		/// <param name="userName"></param>
		/// <returns>IEnumerable<TransportRequest></returns>
		public IEnumerable<TransportRequest> GetByUserName(string userName)
		{
			return RequestsQ.Where(r => r.User.UserName == userName);
		}

		/// <summary>
		/// Finds Transport Requests Whose Current User Responsible For Confirm Has Specified UserName
		/// </summary>
		/// <param name="userName"></param>
		/// <returns>IEnumerable<TransportRequest></returns>
		public IEnumerable<TransportRequest> GetByConfirmCurrentStateUserName(string userName)
		{
			return RequestsQ.AsEnumerable().Where(r => r.ConfirmChain.ConfirmChainState?.User?.UserName == userName);
		}

		/// <summary>
		/// Finds Transport Requests Whose User Has One Of Specified UserName's
		/// </summary>
		/// <param name="userName"></param>
		/// <returns>IEnumerable<TransportRequest></returns>
		public IEnumerable<TransportRequest> GetByUserNames(params string[] userNames)
		{
			var requests = new List<TransportRequest>();
			foreach (var userName in userNames)
			{
				requests.AddRange(GetByUserName(userName));
			}
			return requests;
		}
	}
}
