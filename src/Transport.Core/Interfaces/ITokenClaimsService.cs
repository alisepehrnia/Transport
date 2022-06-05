using System.Threading.Tasks;

namespace Transport.Core.Interfaces
{
	public interface ITokenClaimsService
	{
		Task<string> GetTokenAsync(string userName);
	}
}
