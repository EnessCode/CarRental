using CarRental.Application.Common;
using CarRental.Application.Features.CQRS.Commands.CarCommands;
using CarRental.Application.Features.CQRS.Handlers.CarHandlers;
using CarRental.Application.Features.CQRS.Queries.CarQueries;
using CarRental.Application.Features.CQRS.Results.CarResults;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsController(
		CreateCarCommandHandler createCarCommandHandler,
		GetCarQueryHandler getCarQueryHandler,
		GetCarByIdQueryHandler getCarByIdHandler,
		UpdateCarCommandHandler updateCarCommandHandler,
		RemoveCarCommandHandler removeCarCommandHandler,
		GetCarWithBrandQueryHandler getCarWithBrandQueryHandler
		) : ControllerBase
	{

		[HttpGet]
		public async Task<IActionResult> CarList()
		{
			var values = await getCarQueryHandler.Handle();
			return Ok(ApiResponse<List<GetCarQueryResult>>.SuccessResponse(values, "Araba listesi getirildi"));
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> CarById(int id)
		{
			var value = await getCarByIdHandler.Handle(new GetCarByIdQuery(id));
			return Ok(ApiResponse<GetCarByIdQueryResult>.SuccessResponse(value, "Kayıt getirildi"));
		}

		[HttpPost]
		public async Task<IActionResult> CreateCar(CreateCarCommand command)
		{
			var createdData = await createCarCommandHandler.Handle(command);
			return StatusCode(201, ApiResponse<CreateCarCommand>.SuccessResponse(createdData, "Araba bilgisi başarıyla eklendi"));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveCar(int id)
		{
			var removedData = await removeCarCommandHandler.Handle(new RemoveCarCommand(id));
			return Ok(ApiResponse<RemoveCarCommand>.SuccessResponse(removedData, "Kayıt silindi"));
		}

		[HttpPut]
		public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
		{
			var updatedData = await updateCarCommandHandler.Handle(command);
			return Ok(ApiResponse<UpdateCarCommand>.SuccessResponse(updatedData, "Araba bilgisi başarıyla güncellendi"));
		}

		[HttpGet("GetCarWithBrand")]
		public async Task<IActionResult> GetCarWithBrand()
		{
			var values = await getCarWithBrandQueryHandler.Handle();
			return Ok(ApiResponse<List<GetCarWithBrandQueryResult>>.SuccessResponse(values, "Araba ve marka bilgileri getirildi"));
		}
	}
}
