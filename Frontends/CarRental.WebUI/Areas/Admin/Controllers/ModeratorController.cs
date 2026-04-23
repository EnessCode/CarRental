using Microsoft.AspNetCore.Mvc;
using CarRental.Dto;
using CarRental.Dto.ModeratorDtos;
using Newtonsoft.Json;
using System.Text;

namespace CarRental.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ModeratorController(IHttpClientFactory httpClientFactory) : BaseAdminController
	{
		public async Task<IActionResult> Index()
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");
			var responseMessage = await client.GetAsync("AppUsers/GetAppUsersByRole/Moderator");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();

				var apiResponse = JsonConvert.DeserializeObject<ResultApiResponseDto<List<ResultModeratorDto>>>(jsonData);

				if (apiResponse != null && apiResponse.Success)
				{
					return View(apiResponse.Data);
				}
			}
			return View(new List<ResultModeratorDto>());
		}

		public async Task<IActionResult> DismissModerator(int id)
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");

			var changeRoleDto = new { AppUserId = id, NewRoleId = 3 }; 
			var jsonData = JsonConvert.SerializeObject(changeRoleDto);
			var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PostAsync("AppUsers/ChangeRole", stringContent);

			return RedirectToAction("Index", "Moderator", new { area = "Admin" });
		}

		public IActionResult AssignNewModerator()
		{
			return RedirectToAction("Index", "AppUser", new { area = "Admin" });
		}
	}
}