using System.Threading.Tasks;

namespace X.Core.Interfaces
{
	public interface ITokenClaimsService
	{
		Task<string> GetTokenAsync(string userName);
	}
}
