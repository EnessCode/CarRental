using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Queries.RentACarQueries;
using CarRental.Application.Features.Mediator.Results.RentACarResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RentACarsController(IMediator mediator) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetRentACarListByLocation([FromQuery] GetRentACarQuery getRentACarQuery)
		{
			var values = await mediator.Send(getRentACarQuery);
			return Ok(ApiResponse<List<GetRentACarQueryResult>>.SuccessResponse(values, "Seçilen lokasyondaki araçlar başarıyla listelendi"));
		}
	}
}
