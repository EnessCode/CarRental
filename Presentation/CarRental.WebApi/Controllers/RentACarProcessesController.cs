using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Commands.RentACarProcessCommands;
using CarRental.Application.Features.Mediator.Queries.RentACarProcessQueries;
using CarRental.Application.Features.Mediator.Results.RentACarProcessResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RentACarProcessesController(IMediator mediator) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetRentACarProcessList()
		{
			var values = await mediator.Send(new GetRentACarProcessQuery());
			return Ok(ApiResponse<List<GetRentACarProcessQueryResult>>.SuccessResponse(values));
		}

		[HttpPost("UpdateStatus")]
		public async Task<IActionResult> UpdateStatus(UpdateRentACarProcessStatusCommand command)
		{
			await mediator.Send(command);
			return Ok(ApiResponse<NoContent>.SuccessResponse("Süreç durumu güncellendi."));
		}
	}
}
