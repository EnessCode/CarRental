using CarRental.Dto;
using CarRental.Dto.ModeratorDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace CarRental.WebUI.Areas.Moderator.Controllers
{
	[Area("Moderator")]
	public class ProfileController(IHttpClientFactory httpClientFactory) : BaseModeratorController
	{
		private string GetUserId() => User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");
			var response = await client.GetAsync("Moderators/GetProfile/" + GetUserId());

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<ResultApiResponseDto<ResultModeratorProfileDto>>(jsonData);
				return View(value.Data);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(ResultModeratorProfileDto dto)
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");
			var jsonData = JsonConvert.SerializeObject(dto);
			var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PutAsync("Moderators/UpdateProfile", content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Dashboard");
			}
			return View(dto);
		}
	}
}
