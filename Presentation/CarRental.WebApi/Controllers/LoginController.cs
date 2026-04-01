using CarRental.Application.Features.Mediator.Queries.AppUserQueries;
using CarRental.Application.Tools;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController(IMediator mediator, JwtTokenGenerator jwtTokenGenerator) : ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> Index(GetCheckAppUserQuery getCheckAppUserQuery)
		{
			var values = await mediator.Send(getCheckAppUserQuery);

			if (values.IsExist)
			{
				var token = jwtTokenGenerator.GenerateToken(values);
				return Ok(token);
			}
			else
			{
				return BadRequest("Kullanıcı adı veya şifre hatalı!");
			}
		}
	}
}