using CarRental.Dto;
using CarRental.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarRental.WebUI.Areas.Moderator.Controllers
{
	[Area("Moderator")]
	public class CommentController(IHttpClientFactory httpClientFactory) : BaseModeratorController
	{
		public async Task<IActionResult> Index()
		{
			var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
			var client = httpClientFactory.CreateClient("CarRentalApi");

			var responseMessage = await client.GetAsync("Comments/GetCommentsByAuthorId/" + userId);

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var apiResponse = JsonConvert.DeserializeObject<ResultApiResponseDto<List<ResultCommentDto>>>(jsonData);
				return View(apiResponse.Data);
			}
			return View(new List<ResultCommentDto>());
		}

		public async Task<IActionResult> DeleteComment(int id)
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");
			await client.DeleteAsync("Comments/" + id);
			return RedirectToAction("Index");
		}
	}
}
