using CarRental.Application.Dtos;
using CarRental.Application.Features.Mediator.Results.AppUserResults;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarRental.Application.Tools
{
	public class JwtTokenGenerator(IConfiguration configuration)
	{
		public TokenResponseDto GenerateToken(GetCheckAppUserQueryResult model)
		{
			var claims = new List<Claim>();

			if (!string.IsNullOrWhiteSpace(model.Role))
				claims.Add(new Claim(ClaimTypes.Role, model.Role));

			claims.Add(new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()));

			if (!string.IsNullOrWhiteSpace(model.Username))
				claims.Add(new Claim(ClaimTypes.Name, model.Username));

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[JwtTokenDefaults.SecretKey]));
			var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var expiresDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.ExpireDays);

			var token = new JwtSecurityToken(
				issuer: configuration[JwtTokenDefaults.ValidIssuer],
				audience: configuration[JwtTokenDefaults.ValidAudience],
				claims: claims,
				expires: expiresDate,
				signingCredentials: signingCredentials
			);

			var tokenHandler = new JwtSecurityTokenHandler();
			return new TokenResponseDto
			{
				Token = tokenHandler.WriteToken(token),
				ExpireDate = expiresDate
			};
		}
	}
}