using CarRental.Dto;
using CarRental.Dto.RentACarProcessDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarRental.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class RentACarProcessController(IHttpClientFactory httpClientFactory) : BaseAdminController
	{
		public async Task<IActionResult> Index()
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");

			var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

			var responseMessage = await client.GetAsync("RentACarProcesses");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultApiResponseDto<List<ResultRentACarProcessDto>>>(jsonData);
				return View(values.Data);
			}
			return View(new List<ResultRentACarProcessDto>());
		}

		public async Task<IActionResult> DeliverCar(int id)
		{
			return await ChangeStatus(id, "Müşteride");
		}

		public async Task<IActionResult> ReceiveCar(int id)
		{
			return await ChangeStatus(id, "Tamamlandı");
		}

		private async Task<IActionResult> ChangeStatus(int id, string status)
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");
			var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

			var command = new { Id = id, NewStatus = status };
			var jsonData = JsonConvert.SerializeObject(command);
			var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

			await client.PostAsync("RentACarProcesses/UpdateStatus", content);
			return RedirectToAction("Index");
		}
	}
}