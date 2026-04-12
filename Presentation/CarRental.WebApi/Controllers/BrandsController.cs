using CarRental.Application.Common;
using CarRental.Application.Features.CQRS.Commands.BrandCommands;
using CarRental.Application.Features.CQRS.Handlers.BrandHandlers;
using CarRental.Application.Features.CQRS.Queries.BrandQueries;
using CarRental.Application.Features.CQRS.Results.BrandResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class BrandsController(
		CreateBrandCommandHandler createBrandCommandHandler,
		GetBrandQueryHandler getBrandQueryHandler,
		GetBrandByIdQueryHandler getBrandByIdQueryHandler,
		UpdateBrandCommandHandler updateBrandCommandHandler,
		RemoveBrandCommandHandler removeBrandCommandHandler
		) : ControllerBase
	{

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> BrandList()
		{
			var values = await getBrandQueryHandler.Handle();
			return Ok(ApiResponse<List<GetBrandQueryResult>>.SuccessResponse(values, "Araç markaları listesi başarıyla getirildi"));
		}

		[AllowAnonymous]
		[HttpGet("{id}")]
		public async Task<IActionResult> BrandById(int id)
		{
			var value = await getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
			return Ok(ApiResponse<GetBrandByIdQueryResult>.SuccessResponse(value, "İlgili marka bilgisi başarıyla getirildi"));
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
		{
			var createdData = await createBrandCommandHandler.Handle(command);
			return StatusCode(201, ApiResponse<CreateBrandCommand>.SuccessResponse(createdData, "Yeni marka kaydı başarıyla eklendi"));
		}

		[Authorize(Roles = "Admin")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveBrand(int id)
		{
			var removedData = await removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
			return Ok(ApiResponse<RemoveBrandCommand>.SuccessResponse(removedData, "Marka kaydı sistemden silindi"));
		}

		[Authorize(Roles = "Admin")]
		[HttpPut]
		public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
		{
			var updatedData = await updateBrandCommandHandler.Handle(command);
			return Ok(ApiResponse<UpdateBrandCommand>.SuccessResponse(updatedData, "Marka bilgisi başarıyla güncellendi"));
		}
	}
}
