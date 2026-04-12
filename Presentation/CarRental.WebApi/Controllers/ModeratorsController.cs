using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Commands.ModeratorCommands;
using CarRental.Application.Features.Mediator.Queries.ModeratorQueries;
using CarRental.Application.Features.Mediator.Results.ModeratorResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ModeratorsController(IMediator mediator) : ControllerBase
	{
		[Authorize(Roles = "Admin,Moderator")]
		[HttpGet("GetProfile/{id}")]
		public async Task<IActionResult> GetProfile(int id)
		{
			var result = await mediator.Send(new GetModeratorProfileByIdQuery(id));
			return Ok(ApiResponse<GetModeratorProfileByIdQueryResult>.SuccessResponse(result));
		}

		[Authorize(Roles = "Admin,Moderator")]
		[HttpPut("UpdateProfile")]
		public async Task<IActionResult> UpdateProfile(UpdateModeratorProfileCommand command)
		{
			await mediator.Send(command);
			return Ok(ApiResponse<NoContent>.SuccessResponse(null, "Profil başarıyla güncellendi."));
		}
	}
}
