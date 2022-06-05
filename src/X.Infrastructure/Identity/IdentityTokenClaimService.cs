using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using X.Core.Constants;
using X.Core.Interfaces;

namespace X.Infrastructure.Identity
{
	public class IdentityTokenClaimService : ITokenClaimsService
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public IdentityTokenClaimService(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}

		/// <summary>
		/// Generates JWT Token For Specified User. This Method Uses UserName, User Roles,
		/// JWTTokenExpireDuration, JWTTokenKey and HmacSha256Signature To Make Tokens
		/// </summary>
		/// <param name="userName"></param>
		/// <returns></returns>
		public async Task<string> GetTokenAsync(string userName)
		{
			var claims = await GetUserClaims(userName);

			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims.ToArray()),
				Expires = DateTime.UtcNow.Add(AuthConstants.JWTTokenExpireDuration),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(AuthConstants.JWTTokenKey),
					SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);

			return tokenHandler.WriteToken(token);
		}

		/// <summary>
		/// Find User, Its's Roles And Constructs List Of Claims With That
		/// </summary>
		/// <returns>User Claim's List</returns>
		private async Task<List<Claim>> GetUserClaims(string userName)
		{
			var user = await _userManager.FindByNameAsync(userName);
			var roles = await _userManager.GetRolesAsync(user.Id);
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, userName)
			};

			foreach (var role in roles)
			{
				claims.Add(new Claim(ClaimTypes.Role, role));
			}

			return claims;
		}
	}
}