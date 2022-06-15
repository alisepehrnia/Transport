using System.Threading.Tasks;

namespace Transport.Core.Interfaces
{
	/// <summary>
	/// Interface For IdentityUserClaimService
	/// </summary>
	public interface ITokenClaimsService
	{
		Task<string> GetTokenAsync(string userName);
	}
}
