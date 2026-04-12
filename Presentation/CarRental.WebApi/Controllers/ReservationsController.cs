using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Commands.ReservationCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
	}
}
