using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Ardalis.Specification;
using Ardalis.Specification.EntityFramework6;
using Transport.Core.Entities.Transport;
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

			var request = Requests.Include(r => r.ConfirmChain.Confirms)
				.FirstOrDefault(r => r.RequestId == id);
			if (request == null)
			{
				result.HttpStatusCode = HttpStatusCode.NotFound;
				return result;
			}

			result.Request = request;
			return result;
		}

		public async Task<TransportRequest> GetByIdAsync(params object[] pk)
		{
			return await Requests.FindAsync(pk);
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
			var higherLevel_userLevels = AppUserRoleLevelQueries.GetHigherLevels(_db, current.Level).ToUserLevelTuples();
			return new TransportRequest(current.User, travelDateTime, address, higherLevel_userLevels);
		}

		/// <summary>
		/// Finds Transport Requests Whose User Have Specified UserName
		/// </summary>
		/// <param name="userName"></param>
		/// <returns>IEnumerable<TransportRequest></returns>
		public IEnumerable<TransportRequest> GetByUserName(string userName)
		{
			return Requests.Where(r => r.User.UserName == userName);
		}
	}
}
