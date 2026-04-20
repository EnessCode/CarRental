using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Commands.AppUserCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CarRental.WebApi.Controllers
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class RegisterController(IMediator mediator) : ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> Index(CreateAppUserCommand command)
		{
			try
			{
				await mediator.Send(command);
				return StatusCode(201, ApiResponse<CreateAppUserCommand>.SuccessResponse(command, "Kullanıcı kaydı başarıyla gerçekleştirildi."));
			}
			catch (Exception ex)
			{
				return BadRequest(ApiResponse<NoContent>.FailResponse(ex.Message));
			}
		}
	}
}

