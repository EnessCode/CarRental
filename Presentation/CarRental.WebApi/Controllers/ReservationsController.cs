using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Commands.ReservationCommands;
using CarRental.Application.Features.Mediator.Queries.ReservationQueries;
using CarRental.Application.Features.Mediator.Results.ReservationResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ReservationsController(IMediator mediator) : ControllerBase
	{
		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> CreateReservation(CreateReservationCommand command)
		{
			await mediator.Send(command);
			return Ok(ApiResponse<object>.SuccessResponse(null, "Rezervasyonunuz başarıyla alınmıştır. Müşteri temsilcilerimiz sizinle iletişime geçecektir."));
		}

		[HttpGet]
		public async Task<IActionResult> GetReservationList()
		{
			var values = await mediator.Send(new GetReservationQuery());
			return Ok(ApiResponse<List<GetReservationQueryResult>>.SuccessResponse(values));
		}

		[Authorize(Roles = "Admin")]
		[HttpPost("UpdateStatus")]
		public async Task<IActionResult> UpdateStatus(UpdateReservationStatusCommand command)
		{
			await mediator.Send(command);
			return Ok(ApiResponse<NoContent>.SuccessResponse("Rezervasyon durumu başarıyla güncellendi."));
		}
	}
}
