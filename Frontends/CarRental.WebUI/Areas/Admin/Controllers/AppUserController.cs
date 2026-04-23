using CarRental.Dto;
using CarRental.Dto.AppUserDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarRental.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AppUserController(IHttpClientFactory httpClientFactory) : BaseAdminController
	{
		public async Task<IActionResult> Index()
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");
			var responseMessage = await client.GetAsync("AppUsers");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var apiResponse = JsonConvert.DeserializeObject<ResultApiResponseDto<List<ResultAppUserDto>>>(jsonData);

				if (apiResponse != null && apiResponse.Success)
				{
					return View(apiResponse.Data);
				}
			}
			return View(new List<ResultAppUserDto>());
		}

		public async Task<IActionResult> AssignModerator(int id)
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");
			var changeRoleDto = new { AppUserId = id, NewRoleId = 2 };

			var jsonData = JsonConvert.SerializeObject(changeRoleDto);
			var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

			await client.PostAsync("AppUsers/ChangeRole", content);
			return RedirectToAction("Index");
		}
	}
}