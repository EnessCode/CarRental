using CarRental.Dto;
using CarRental.Dto.ReservationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace CarRental.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ReservationController(IHttpClientFactory httpClientFactory) : BaseAdminController
	{
		private string GetToken() => User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;

		public async Task<IActionResult> Index()
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");

			var token = GetToken();
			if (!string.IsNullOrEmpty(token))
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

			var responseMessage = await client.GetAsync("Reservations");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var apiResponse = JsonConvert.DeserializeObject<ResultApiResponseDto<List<ResultReservationDto>>>(jsonData);

				if (apiResponse != null && apiResponse.Success)
				{
					return View(apiResponse.Data);
				}
			}
			return View(new List<ResultReservationDto>());
		}

		public async Task<IActionResult> ApproveReservation(int id)
		{
			return await UpdateStatus(id, "Onaylandı");
		}

		public async Task<IActionResult> CancelReservation(int id)
		{
			return await UpdateStatus(id, "İptal Edildi");
		}

		private async Task<IActionResult> UpdateStatus(int id, string newStatus)
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");

			var token = GetToken();
			if (!string.IsNullOrEmpty(token))
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

			var updateCommand = new
			{
				ReservationId = id,
				NewStatus = newStatus
			};

			var jsonData = JsonConvert.SerializeObject(updateCommand);
			var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PostAsync("Reservations/UpdateStatus", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return RedirectToAction("Index");
		}
	}
}