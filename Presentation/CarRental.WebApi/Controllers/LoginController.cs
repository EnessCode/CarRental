using CarRental.Application.Common;
using CarRental.Application.Dtos;
using CarRental.Application.Features.Mediator.Commands.AppUserCommands;
using CarRental.Application.Tools;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebApi.Controllers
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController(IMediator mediator, JwtTokenGenerator jwtTokenGenerator) : ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> Index(LoginCommand command)
		{
			var values = await mediator.Send(command);

			if (values != null)
			{
				return Ok(ApiResponse<TokenResponseDto>.SuccessResponse(values, "Giriş işlemi başarıyla tamamlandı."));
			}
			else
			{
				return BadRequest("Kullanıcı adı veya şifre hatalı!");
			}
		}
	}
}