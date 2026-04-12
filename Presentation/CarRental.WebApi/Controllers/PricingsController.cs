using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Commands.PricingCommands;
using CarRental.Application.Features.Mediator.Queries.PricingQueries;
using CarRental.Application.Features.Mediator.Results.PricingResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class PricingsController(IMediator mediator) : ControllerBase
	{
		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> PricingList()
		{
			var values = await mediator.Send(new GetPricingQuery());
			return Ok(ApiResponse<List<GetPricingQueryResult>>.SuccessResponse(values, "Ödeme türleri başarıyla getirildi"));
		}

		[AllowAnonymous]
		[HttpGet("{id}")]
		public async Task<IActionResult> PricingById(int id)
		{
			var value = await mediator.Send(new GetPricingByIdQuery(id));
			return Ok(ApiResponse<GetPricingByIdQueryResult>.SuccessResponse(value, "İlgili ödeme türü bilgisi başarıyla getirildi"));
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public async Task<IActionResult> CreatePricing(CreatePricingCommand command)
		{
			var createdData = await mediator.Send(command);
			return StatusCode(201, ApiResponse<CreatePricingCommand>.SuccessResponse(createdData, "Yeni ödeme türü başarıyla oluşturuldu"));
		}

		[Authorize(Roles = "Admin")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> RemovePricing(int id)
		{
			var removedData = await mediator.Send(new RemovePricingCommand(id));
			return Ok(ApiResponse<RemovePricingCommand>.SuccessResponse(removedData, "Ödeme türü başarıyla silindi"));
		}

		[Authorize(Roles = "Admin")]
		[HttpPut]
		public async Task<IActionResult> UpdatePricing(UpdatePricingCommand command)
		{
			var updatedData = await mediator.Send(command);
			return Ok(ApiResponse<UpdatePricingCommand>.SuccessResponse(updatedData, "Ödeme türü bilgisi başarıyla güncellendi"));
		}
	}
}