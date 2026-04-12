using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Commands.FeatureCommands;
using CarRental.Application.Features.Mediator.Queries.FeatureQueries;
using CarRental.Application.Features.Mediator.Results.FeatureResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class FeaturesController(IMediator mediator) : ControllerBase
	{
		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> FeatureList()
		{
			var values = await mediator.Send(new GetFeatureQuery());
			return Ok(ApiResponse<List<GetFeatureQueryResult>>.SuccessResponse(values, "Araç özellik listesi başarıyla getirildi"));
		}

		[AllowAnonymous]
		[HttpGet("{id}")]
		public async Task<IActionResult> FeatureById(int id)
		{
			var value = await mediator.Send(new GetFeatureByIdQuery(id));
			return Ok(ApiResponse<GetFeatureByIdQueryResult>.SuccessResponse(value, "İlgili özellik kaydı başarıyla getirildi"));
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public async Task<IActionResult> CreateFeature(CreateFeatureCommand command)
		{
			var createdData = await mediator.Send(command);
			return StatusCode(201, ApiResponse<CreateFeatureCommand>.SuccessResponse(createdData, "Yeni özellik kaydı başarıyla oluşturuldu"));
		}

		[Authorize(Roles = "Admin")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveFeature(int id)
		{
			var removedData = await mediator.Send(new RemoveFeatureCommand(id));
			return Ok(ApiResponse<RemoveFeatureCommand>.SuccessResponse(removedData, "Özellik kaydı başarıyla silindi"));
		}

		[Authorize(Roles = "Admin")]
		[HttpPut]
		public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand command)
		{
			var updatedData = await mediator.Send(command);
			return Ok(ApiResponse<UpdateFeatureCommand>.SuccessResponse(updatedData, "Özellik bilgisi başarıyla güncellendi"));
		}
	}
}
