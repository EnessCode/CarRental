using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Commands.CommentCommands;
using CarRental.Application.Features.Mediator.Queries.CommentQueries;
using CarRental.Application.Features.Mediator.Queries.StatisticsQueries;
using CarRental.Application.Features.Mediator.Results.CommentResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CommentsController(IMediator mediator) : ControllerBase
	{
		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> CommentList()
		{
			var values = await mediator.Send(new GetCommentQuery());
			return Ok(ApiResponse<List<GetCommentQueryResult>>.SuccessResponse(values, "Yorum listesi başarıyla getirildi"));
		}

		[Authorize(Roles = "Admin")]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetComment(int id)
		{
			var value = await mediator.Send(new GetCommentByIdQuery(id));
			return Ok(ApiResponse<GetCommentByIdQueryResult>.SuccessResponse(value, "İlgili yorum kaydı başarıyla getirildi"));
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> CreateComment(CreateCommentCommand command)
		{
			await mediator.Send(command);
			return StatusCode(201, ApiResponse<string>.SuccessResponse(null, "Yorum başarıyla eklendi"));
		}

		[Authorize(Roles = "Admin,Moderator")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveComment(int id)
		{
			await mediator.Send(new RemoveCommentCommand(id));
			return Ok(ApiResponse<string>.SuccessResponse(null, "Yorum başarıyla silindi"));
		}

		[Authorize(Roles = "Admin")]
		[HttpPut]
		public async Task<IActionResult> UpdateComment(UpdateCommentCommand command)
		{
			await mediator.Send(command);
			return Ok(ApiResponse<string>.SuccessResponse(null, "Yorum başarıyla güncellendi"));
		}

		[AllowAnonymous]
		[HttpGet("CommentListByBlog/{id}")]
		public async Task<IActionResult> CommentListByBlog(int id)
		{
			var values = await mediator.Send(new GetCommentByBlogIdQuery(id));
			return Ok(ApiResponse<List<GetCommentByBlogIdQueryResult>>.SuccessResponse(values, "Bloga ait yorumlar başarıyla getirildi"));
		}

		[Authorize(Roles = "Admin,Moderator")]
		[HttpGet("GetCommentsByAuthorId/{id}")]
		public async Task<IActionResult> GetCommentsByAuthorId(int id)
		{
			var values = await mediator.Send(new GetCommentsByAuthorIdQuery(id));
			return Ok(ApiResponse<List<GetCommentsByAuthorIdQueryResult>>.SuccessResponse(values));
		}
	}
}