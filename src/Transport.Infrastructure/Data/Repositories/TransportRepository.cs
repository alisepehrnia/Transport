using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using Ardalis.Specification.EntityFramework6;
using Transport.Infrastructure.Data.DataAccess;

namespace Transport.Infrastructure.Data
{
	public class TransportRepository<T> : RepositoryBase<T> where T : class
	{
		protected readonly TransportDbContext _dbContext;

		public TransportRepository(TransportDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<T>> GetAllAsync()
		{
			return await _dbContext.Set<T>().ToListAsync();
		}

		public async Task<T> GetByIdAsync(params object[] pk)
		{
			return await _dbContext.Set<T>().FindAsync(pk);
		}

		public IEnumerable<T> FindWithSpecificationPattern(ISpecification<T> specification = null)
		{
			return new SpecificationEvaluator().GetQuery(_dbContext.Set<T>().AsQueryable(), specification);
		}
	}
}
