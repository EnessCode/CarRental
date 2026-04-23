using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Commands.AppUserCommands;
using CarRental.Application.Features.Mediator.Queries.AppUserQueries;
using CarRental.Application.Features.Mediator.Results.AppUserResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AppUsersController(IMediator mediator) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> AppUserList()
		{
			var values = await mediator.Send(new GetAppUserQuery());
			return Ok(ApiResponse<List<GetAppUserQueryResult>>.SuccessResponse(values, "Kullanıcı listesi başarıyla getirildi"));
		}

		[HttpGet("GetAppUsersByRole/{roleName}")]
		public async Task<IActionResult> GetAppUsersByRole(string roleName)
		{
			var values = await mediator.Send(new GetAppUserByRoleQuery(roleName));
			return Ok(ApiResponse<List<GetAppUserQueryResult>>.SuccessResponse(values, $"{roleName} rolündeki kullanıcılar başarıyla getirildi"));
		}

		[HttpPost("ChangeRole")]
		public async Task<IActionResult> ChangeRole(ChangeUserRoleCommand command)
		{
			await mediator.Send(command);
			return Ok(ApiResponse<NoContentResult>.SuccessResponse(null, "Kullanıcı rolü başarıyla güncellendi."));
		}
	}
}