using CarRental.Application.Common;
using CarRental.Application.Features.CQRS.Commands.AboutCommands;
using CarRental.Application.Features.CQRS.Handlers.AboutHandlers;
using CarRental.Application.Features.CQRS.Queries.AboutQueries;
using CarRental.Application.Features.CQRS.Results.AboutResults;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AboutsController(
		CreateAboutCommandHandler createAboutCommandHandler,
		GetAboutQueryHandler getAboutQueryHandler,
		GetAboutByIdQueryHandler getAboutByIdHandler,
		UpdateAboutCommandHandler updateAboutCommandHandler,
		RemoveAboutCommandHandler removeAboutCommandHandler
		) : ControllerBase
	{

		[HttpGet]
		public async Task<IActionResult> AboutList()
		{
			var values = await getAboutQueryHandler.Handle();
			return Ok(ApiResponse<List<GetAboutQueryResult>>.SuccessResponse(values, "Hakkımızda listesi getirildi"));
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> AboutById(int id)
		{
			var value = await getAboutByIdHandler.Handle(new GetAboutByIdQuery(id));
			return Ok(ApiResponse<GetAboutByIdQueryResult>.SuccessResponse(value, "Kayıt getirildi"));
		}

		[HttpPost]
		public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
		{
			var createdData = await createAboutCommandHandler.Handle(command);
			return StatusCode(201, ApiResponse<CreateAboutCommand>.SuccessResponse(createdData, "Hakkımızda bilgisi başarıyla eklendi"));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveAbout(int id)
		{
			var removedData = await removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
			return Ok(ApiResponse<RemoveAboutCommand>.SuccessResponse(removedData, "Kayıt silindi"));
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
		{
			var updatedData = await updateAboutCommandHandler.Handle(command);
			return Ok(ApiResponse<UpdateAboutCommand>.SuccessResponse(updatedData, "Güncelleme başarılı"));
		}
	}
}